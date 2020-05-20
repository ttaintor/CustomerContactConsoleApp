using Newtonsoft.Json;

namespace OpenWeatherMapApi
{
   public class Sys
   {
      [JsonProperty("pod")]
      public string Pod { get; set; }
   }
}
