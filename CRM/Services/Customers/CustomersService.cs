using csbi_test_clients_dictionary.Data;
using csbi_test_clients_dictionary.Data.Entities;
using csbi_test_clients_dictionary.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csbi_test_clients_dictionary.Services.Customers
{
    public class CustomersService: ICustomers
    {
        private readonly CrmDbContext _crmDbContext;

        public CustomersService(CrmDbContext crmDbContext)
        {
            _crmDbContext = crmDbContext;
        }

        /// <summary>
        /// Регистрация сведений о клиенте
        /// </summary>
        /// <param name="FirstName">имя</param>
        /// <param name="SurName">фамилия</param>
        /// <param name="LastName">отчество</param>
        /// <param name="Tel">телефон</param>     

        public async Task<OperationStatus> CreateCustomer(string FirstName, string SurName, string LastName, string Tel)
        { 
            Console.WriteLine($"Регистрация сотрудника {FirstName} {SurName} {LastName} {Tel}");
            _crmDbContext.Customers.Add(new CustomerInfo()
            {
                FirstName = FirstName.Trim(),
                SurName = SurName.Trim(),
                LastName = LastName.Trim(),
                Tel = Tel.Trim()
            });
            return new OperationStatus()
            {
                Status = await _crmDbContext.SaveChangesAsync()
            };
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SearchResults<CustomerInfo>> GetCustomers(int page, int size)
        {
            var started = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            try
            {

                var results = _crmDbContext.Customers;
                var res = new SearchResults<CustomerInfo>()
                {
                    CompletedTime = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    StartedTime = started,
                    TotalResults = results.Count(),
                    PageNumber = page,
                    PageSize = size,
                    TotalPages = results.Count() % size == 0 ? ((int)(results.Count() / size)) : 1 + ((int)((results.Count() - (results.Count() % size)) / size)),

                    Result = results.Skip((page - 1) * size).Take(size).ToArray(),
                    Status = 1
                };

                Console.WriteLine(JsonConvert.SerializeObject(res));

                return res;
            }
            catch (Exception ex)
            {
                return new SearchResults<CustomerInfo>()
                {
                    Result = null,
                    Status = -1
                };
            }
        }


        /// <summary>
        /// Поиск сведений о клиентах по поисковому запросу 
        /// </summary>        
        /// <param name="page">номер страницы</param>
        /// <param name="size">размер страницы</param>
        /// <returns></returns>
        public async Task<SearchResults<CustomerInfo>> SearchCustomers(int page, int size, string query)
        {
            var started = DateTimeOffset.Now.ToUnixTimeMilliseconds();
           
            try
            {
                
                var results = _crmDbContext.Customers
                    .Where(info=>  info.FirstName.ToLower().IndexOf(query.ToLower())!=-1
                    || info.LastName.ToLower().IndexOf(query.ToLower()) != -1
                    || info.SurName.ToLower().IndexOf(query.ToLower()) != -1
                    
                    );
                 
                
                
                var res = new SearchResults<CustomerInfo>()
                {
                    CompletedTime = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    StartedTime = started,
                    TotalResults = results.Count(),
                    PageNumber = page,
                    PageSize = size,
                    TotalPages = results.Count()%size==0? ((int)(results.Count()/size)): 1+((int)((results.Count()-(results.Count()%size))/size)),
                    
                    Result = results.Skip((page-1)*size).Take(size).ToArray(),
                    Status = 1
                };

                Console.WriteLine(JsonConvert.SerializeObject(res));

                return res;
            }
            catch (Exception ex)
            {
                return new SearchResults<CustomerInfo>()
                {
                    Result = null,
                    Status = -1
                };
            }
        }
    }
}
