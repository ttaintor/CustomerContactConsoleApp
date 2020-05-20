using Newtonsoft.Json;

namespace OpenWeatherMapApi
{
   public class Wind
   {
      [JsonProperty("speed")]
      public float Speed { get; set; }

      [JsonProperty("deg")]
      public int Direction { get; set; }
   }
}
