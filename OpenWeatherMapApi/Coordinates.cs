using Newtonsoft.Json;

namespace OpenWeatherMapApi
{
   public class Coordinates
   {
      [JsonProperty("lat")]
      public float Latitude { get; set; }

      [JsonProperty("lon")]
      public float Longitude { get; set; }
   }
}
