using csbi_test_clients_dictionary.Data.Entities;
using csbi_test_clients_dictionary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csbi_test_clients_dictionary.Services.Customers
{
    public interface ICustomers
    {

        Task<OperationStatus> CreateCustomer(string firstName, string surName, string lastName, string tel);
        Task<SearchResults<CustomerInfo>> GetCustomers(int page, int size);
        Task<SearchResults<CustomerInfo>> SearchCustomers(int page, int size,   string  query);
    }
}
