using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CustomerContactConsoleApp
{
   class Program
   {
      private static IServiceProvider serviceProvider;

      static void Main(string[] args)
      {
         // TODO: determine if we need to add environment-specific settings. There isn't anything in the specifications I've seen yet, so I'm leaving it out for now.
         var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false);

         var configuration = builder.Build();

         // TODO: talk to the architect about how things should really be logged rather than to the console window. Without knowing more about the application environment, doing more (like logging to a file or database) is a waste of time.
         var serviceCollection = new ServiceCollection()
            .AddOptions()
            .AddLogging(logging =>
            {
               logging.AddConfiguration(configuration.GetSection("Logging"));
               logging.AddConsole();
            })
            .Configure<WeatherApiConfig>(configuration.GetSection(nameof(WeatherApiConfig)))
            .AddSingleton<IContactMethodServiceProvider, ContactMethodServiceProvider>();

         serviceProvider = serviceCollection.BuildServiceProvider();

         DisplayData().GetAwaiter().GetResult();
      }

      static async Task DisplayData()
      {
         IEnumerable<ContactMethod> contactMethods;
         IContactMethodServiceProvider contactMethodserviceProvider = serviceProvider.GetService<IContactMethodServiceProvider>();
         contactMethods = await contactMethodserviceProvider.GetContactMethodsForCity("Minneapolis");

         if (contactMethods != null)
         {
            foreach (var contactMethod in contactMethods)
            {
               Console.WriteLine($"Date: {contactMethod.ContactDate.ToShortDateString()}  Outreach method: {contactMethod.ContactType}");
            }
         }
         else
         {
            // TODO: talk to team about what to do in situations where there is an error. Design document didn't specify how to handle.
            Console.WriteLine("There was an error retrieving data for contact methods. Check error logs.");
         }

         return; 
      }
   }
}
