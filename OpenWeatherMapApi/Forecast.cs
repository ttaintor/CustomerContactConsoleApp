using System;
using Newtonsoft.Json;

namespace OpenWeatherMapApi
{
   public class Forecast
   {
      private DateTime unixEpochStartDate;
      private long timeOfForecastUnixUTC;

      public Forecast ()
      {
         unixEpochStartDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
      }

      [JsonProperty("dt")]
      public long TimeOfForecastUnixUTC
      {
         get
         {
            return timeOfForecastUnixUTC;
         }
         set
         {
            timeOfForecastUnixUTC = value;
            ForecastDateTime = unixEpochStartDate.AddSeconds(value);
         }
      }

      [JsonProperty("dt_txt")]
      public string TimeOfForecastText { get; set; }

      public DateTime ForecastDateTime { get; private set; }

      public TimeSpan TimeOfDay
      {
         get
         {
            return ForecastDateTime.TimeOfDay;
         }
      }

      [JsonProperty("main")]
      public MainValues Main { get; set; }

      [JsonProperty("weather")]
      public Weather[] Weather { get; set; }

      [JsonProperty("clouds")]
      public Clouds Clouds { get; set; }

      [JsonProperty("wind")]
      public Wind Wind { get; set; }

      [JsonProperty("sys")]
      public Sys Sys { get; set; }

      [JsonProperty("rain")]
      public Rain Rain { get; set; }

      [JsonProperty("snow")]
      public Snow Snow { get; set; }
   }
}
