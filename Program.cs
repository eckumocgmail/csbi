using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using csbi_test_clients_dictionary.Data;
using csbi_test_clients_dictionary.Services.Customers;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace csbi_test_clients_dictionary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (CrmDbContext crmDb = new CrmDbContext())
            {
                var initiallizer = new CrmDbInitiallizer();
                initiallizer.DoInit(crmDb);

                var service = new CustomersService(crmDb);
                Console.WriteLine(JsonConvert.SerializeObject(service.SearchCustomers(1, 10, "Анатолий").Result.Result));
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
