using AxaAssistanceTest.Models.ApplicationLogic.Exceptions;
using AxaAssistanceTest.Models.Entities.Customers;
using AxaAssistanceTest.Models.Repositories.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AxaAssistanceTest.Models.DomainLogic.Service
{
    /// <summary>
    /// Class holding the business logic for the CRUD operations of the Customer entity.
    /// </summary>
    public class CustomerService
    {
        private ICustomerRepository CustomerRepository;

        public CustomerService(ICustomerRepository CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }

        /// <summary>
        /// Searches the Data Source for a complete List of Customer objects.
        /// </summary>
        /// <returns>
        /// Returns a list of all the Customer objects found in the DataSource, an empty List if none are found.
        /// </returns>
        public List<Customer> ListCustomers()
        {
            List<Customer> customers = this.CustomerRepository.GetAllCustomers();
            customers = customers.OrderBy(c => c.LastName).ToList();

            return customers;
        }

        /// <summary>
        /// Searches the Data Source for a Customer object that matches the provided Id
        /// </summary>
        /// <returns>
        /// Returns a single Customer object if found.
        /// </returns>
        /// <exception cref="EntityNotFoundException">Thrown when a Customer is not found with the provided Id.</exception>
        public Customer GetCustomer(string id)
        {
            Customer customer = this.CustomerRepository.GetCustomer(id);

            if (customer == null)
            {
                throw new EntityNotFoundException(string.Format(ResponseMessages.CustomerNotFound, id));
            }

            return customer;
        }

        /// <summary>
        /// Stores a Customer object in the Data Source.
        /// </summary>
        public void SaveCustomer(Customer value)
        {
            value.CreationTime = DateTime.Now;
            this.CustomerRepository.SaveCustomer(value);
        }

        /// <summary>
        /// Updates a Customer object in the Data Source that matches the Id of the provided Customer object, if the Customer object doesn't exist, it is created instead.
        /// </summary>
        public void UpdateCustomer(Customer value)
        {
            Customer customer = this.CustomerRepository.GetCustomer(value.Id);

            if (customer != null)
            {
                value.CreationTime = customer.CreationTime;
            }
            else
            {
                value.CreationTime = DateTime.Now;
            }
            value.ModificationTime = DateTime.Now;
            this.CustomerRepository.UpdateCustomer(value);
        }

        /// <summary>
        /// Deletes a Customer object from the Data Source.
        /// </summary>
        public void DeleteCustomer(string id)
        {
            this.CustomerRepository.DeleteCustomer(id);
        }
    }
}