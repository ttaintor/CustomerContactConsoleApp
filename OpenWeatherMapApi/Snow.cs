using Newtonsoft.Json;

namespace OpenWeatherMapApi
{
   public class Snow
   {
      [JsonProperty("3h")]
      public float ThreeHourVolume { get; set; }
   }
}
