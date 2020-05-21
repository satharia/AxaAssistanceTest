using AxaAssistanceTest.Models.Entities.Customers;
using System.Collections.Generic;

namespace AxaAssistanceTest.Models.Repositories.Customers
{
    /// <summary>
    /// Data Source accessor for the Customer entity.
    /// </summary>
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomer(string id);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
    }
}