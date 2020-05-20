using Newtonsoft.Json;

namespace OpenWeatherMapApi
{
   public class Clouds
   {
      [JsonProperty("all")]
      public int CloudinessPercentage { get; set; }
   }
}
