using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace CustomerContactConsoleApp
{
   interface IContactMethodServiceProvider
   {
      Task<IEnumerable<ContactMethod>> GetContactMethodsForCity(string location);
   }
}
