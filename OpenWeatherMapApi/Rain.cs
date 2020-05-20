using Newtonsoft.Json;

namespace OpenWeatherMapApi
{
   public class Rain
   {
      [JsonProperty("3h")]
      public float ThreeHourVolume { get; set; }
   }
}
