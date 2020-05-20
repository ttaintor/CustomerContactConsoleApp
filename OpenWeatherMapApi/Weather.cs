using Newtonsoft.Json;

namespace OpenWeatherMapApi
{
   public class Weather
   {
      [JsonProperty("id")]
      public int Id { get; set; }

      [JsonProperty("main")]
      public string MainConditionGroup { get; set; }

      [JsonProperty("description")]
      public string Description { get; set; }

      [JsonProperty("icon")]
      public string Icon { get; set; }
   }
}
