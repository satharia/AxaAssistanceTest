using AxaAssistanceTest.Models.ApplicationLogic.Exceptions;
using AxaAssistanceTest.Models.Entities.Customers;
using AxaAssistanceTest.Models.Repositories.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AxaAssistanceTest.Models.DomainLogic.Service
{
    public class CustomerService
    {
        private ICustomerRepository CustomerRepository;

        public CustomerService(ICustomerRepository CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }

        public List<Customer> ListCustomers()
        {
            List<Customer> customers = this.CustomerRepository.GetAllCustomers();
            customers = customers.OrderBy(c => c.LastName).ToList();

            return customers;
        }

        public Customer GetCustomer(string id)
        {
            Customer customer = this.CustomerRepository.GetCustomer(id);

            if (customer == null)
            {
                throw new EntityNotFoundException(string.Format(ResponseMessages.CustomerNotFound, id));
            }

            return customer;
        }

        public void SaveCustomer(Customer value)
        {
            value.CreationTime = DateTime.Now;
            this.CustomerRepository.SaveCustomer(value);
        }

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

        public void DeleteCustomer(string id)
        {
            this.CustomerRepository.DeleteCustomer(id);
        }
    }
}