using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenWeatherMapApi;

namespace CustomerContactConsoleApp
{
   public class ContactMethodServiceProvider : IContactMethodServiceProvider
   {
      private WeatherApiConfig _apiConfig;
      private ILogger _logger;

      public ContactMethodServiceProvider(IOptions<WeatherApiConfig> apiConfigAccessor, ILogger<ContactMethodServiceProvider> logger)
      {
         _apiConfig = apiConfigAccessor.Value;
         _logger = logger;
      }

      /// <summary>
      /// This method will retrieve an array of forecasts from the OpenWeatherMap service,
      /// pick a forecast for the day, determine which contact method should be used for that
      /// day, and return an IEnumerable that contains all of the days and the associated
      /// contact method.
      /// 
      /// The temperature boundaries for high and low temperatures are configurable, as are
      /// the codes that specify whether a weather condition specifies rain. Yes, this means
      /// that some yo-yo can put in the code for sand storm and have it mean "rain" but you
      /// can't have everything in life. And this is just an example...
      /// </summary>
      /// <param name="location">The name of the city for which we are returning contact methods. Example: "Minneapolis".</param>
      /// <returns></returns>
      public async Task<IEnumerable<ContactMethod>> GetContactMethodsForCity(string location)
      {
         var url = $"{_apiConfig.BaseForecastUrl}q={location.ToLower()},us&units=imperial&APPID={_apiConfig.AppId}";

         // TODO: talk to architect about what should be logged, if anything. I have found it helpful for debugging to log things at various points of during a process.
         _logger.LogInformation($"About to get data from \"{url}\"");

         OpenWeatherMapResponse response = await OpenWeatherMapService.GetForecastsForLocation(url);
         IEnumerable<ContactMethod> contactMethods = null;

         // If there is an object, we got data back from the call to the API. So figure out what the contact method should be for each day returned.
         if (response.OpenWeatherMapData != null)
         {
            // TODO: talk to team about whether we should consider picking a different time of day. I picked 3:00pm because that time is mostly likely to be the highest temperature for the day.

            // Get all forecasts for 3:00pm
            contactMethods = from f in response.OpenWeatherMapData.Forecasts
                             where f.ForecastDateTime.TimeOfDay == new TimeSpan(15, 0, 0)
                             select new ContactMethod { ContactDate = f.ForecastDateTime, ContactType = MethodOfContact(f) };
         }
         else
         {
            // TODO: talk with team about what should be logged. I included the HTTP response the the OpenWeatherMapResponse class in case we wanted to save anything from that for debugging purposes.
            if (response.Excp != null)
            {
               _logger.LogError(response.Excp, "Something really bad happened!");
            }
            else
            {
               _logger.LogInformation($"Probably used a city name that OpenWeatherMap doesn't know about. HTTP response code: {response.HttpResponseMessage.StatusCode.ToString()} : {response.HttpResponseMessage.ReasonPhrase}");
            }
         }

         return contactMethods;
      }

      ContactType MethodOfContact(Forecast forecast)
      {
         // TODO: talk to architect about whether the condition codes should be in a database table
         // TODO: talk to product team about whether we should use the "feels like" temperature instead

         // The "Any" is because there can be more than one Weather object returned.
         if (forecast.Main.Temperature < _apiConfig.LowTemperatureBoundary || forecast.Weather.Any(w => _apiConfig.RainWeatherConditionCodes.Contains(w.Id.ToString())))
         {
            return ContactType.Phone;
         }

         if (forecast.Main.Temperature > _apiConfig.HighTemperatureBoundary && forecast.Clouds.CloudinessPercentage < 100)
         {
            return ContactType.Text;
         }

         if (forecast.Main.Temperature >= _apiConfig.LowTemperatureBoundary && forecast.Main.Temperature <= _apiConfig.HighTemperatureBoundary)
         {
            return ContactType.Email;
         }
         
         //TODO: talk to product team about what to do in the situation where the temperature is above the high temperature boundary but there's no sun

         return ContactType.None;
      }
   }
}
