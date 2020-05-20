using Newtonsoft.Json;

namespace OpenWeatherMapApi
{
   public class MainValues
   {
      [JsonProperty("temp")]
      public float Temperature { get; set; }

      [JsonProperty("feels_like")]
      public float FeelsLike { get; set; }

      [JsonProperty("temp_min")]
      public float MinimumTemperature { get; set; }

      [JsonProperty("temp_max")]
      public float MaximumTemperature { get; set; }

      [JsonProperty("pressure")]
      public int Pressure { get; set; }

      [JsonProperty("sea_level")]
      public int SeaLevelPressure { get; set; }

      [JsonProperty("grnd_level")]
      public int GroundLevelPressure { get; set; }

      [JsonProperty("humidity")]
      public int Humidity { get; set; }

      [JsonProperty("temp_kf")]
      public float temp_kf { get; set; }
   }
}
