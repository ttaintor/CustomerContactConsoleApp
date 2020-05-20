using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OpenWeatherMapApi
{
   public static class OpenWeatherMapService
   {
      static HttpClient client = new HttpClient();

      public static async Task<OpenWeatherMapResponse> GetForecastsForLocation(string path)
      {
         OpenWeatherMapResponse openWeatherMapResponse = new OpenWeatherMapResponse();

         try
         {
            HttpResponseMessage responseMessage = await client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
               openWeatherMapResponse.OpenWeatherMapData = await responseMessage.Content.ReadAsAsync<OpenWeatherMapData>();
               openWeatherMapResponse.HttpResponseMessage = responseMessage;
            }
         }
         catch (Exception excp)
         {
            openWeatherMapResponse.Excp = excp;
         }

         return openWeatherMapResponse;
      }
   }
}
