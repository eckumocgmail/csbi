using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csbi_test_clients_dictionary.Models;
using csbi_test_clients_dictionary.Data.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using csbi_test_clients_dictionary.Services.Customers;

namespace csbi_test_clients_dictionary.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CustomersController : ControllerBase
    {        
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomers _customersService;

        public CustomersController( ILogger<CustomersController> logger, ICustomers customersService )
        {
            _logger = logger;
            _customersService = customersService;
        }




        [HttpPost]
        public async Task<OperationStatus> CreateCustomer(string FirstName, string SurName, string LastName, string Tel)
        {          
            _logger.LogDebug($"CreateCustomer({FirstName},{SurName},{LastName},{Tel})");
            return await _customersService.CreateCustomer(FirstName, SurName, LastName, Tel);            
        }


        [HttpPost]
        public async Task<SearchResults<CustomerInfo>> SearchCustomers(string Query, int Page, int Size)
        {
            _logger.LogDebug($"SearchCustomer({Query},{Page},{Size} )");
            var searchResult = await _customersService.SearchCustomers(Page, Size, Query);
            searchResult.QueryString = Query;
            return searchResult;
        }

        [HttpPost]
        public async Task<SearchResults<CustomerInfo>> GetCustomers(int Page, int Size)
        {
            _logger.LogDebug($"GetCustomers({Page},{Size} )");
            var result = await _customersService.GetCustomers(Page, Size );
            return result;
        }
    }
}
