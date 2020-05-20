using Newtonsoft.Json;

namespace OpenWeatherMapApi
{
   public class OpenWeatherMapData
   {
      [JsonProperty("cod")]
      public string Cod { get; set; }

      [JsonProperty("message")]
      public int Message { get; set; }

      [JsonProperty("cnt")]
      public int ForecastCount { get; set; }

      [JsonProperty("list")]
      public Forecast[] Forecasts { get; set; }

      [JsonProperty("city")]
      public City City { get; set; }
   }
}
