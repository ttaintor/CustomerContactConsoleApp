namespace CustomerContactConsoleApp
{
   public class WeatherApiConfig
   {
      public string BaseForecastUrl { get; set; }
      public string AppId { get; set; }
      public string RainWeatherConditionCodes { get; set; }
      public int LowTemperatureBoundary { get; set; }
      public int HighTemperatureBoundary { get; set; }
   }
}
