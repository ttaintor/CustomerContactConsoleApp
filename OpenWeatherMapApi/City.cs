using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMapApi
{
   public class City
   {
      [JsonProperty("id")]
      public int Id { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("coord")]
      public Coordinates Coordinates { get; set; }

      [JsonProperty("country")]
      public string Country { get; set; }

      [JsonProperty("population")]
      public int Population { get; set; }

      [JsonProperty("timezone")]
      public int Timezone { get; set; }

      [JsonProperty("sunrise")]
      public int Sunrise { get; set; }

      [JsonProperty("sunset")]
      public int Sunset { get; set; }
   }
}
