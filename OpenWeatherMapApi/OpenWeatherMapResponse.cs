using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace OpenWeatherMapApi
{
   public class OpenWeatherMapResponse
   {
      public OpenWeatherMapData OpenWeatherMapData;
      public HttpResponseMessage HttpResponseMessage;
      public Exception Excp;
   }
}
