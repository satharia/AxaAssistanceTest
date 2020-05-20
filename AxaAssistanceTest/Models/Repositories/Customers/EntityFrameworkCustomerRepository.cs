using AxaAssistanceTest.Models.Entities.Customers;
using AxaAssistanceTest.Models.Repositories.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AxaAssistanceTest.Models.Repositories.Customers
{
    public class EntityFrameworkCustomerRepository : ICustomerRepository
    {
        private AxaLibraryContext DbContext;

        public EntityFrameworkCustomerRepository(AxaLibraryContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = this.DbContext.Customers.ToList();
            return customers;
        }

        public Customer GetCustomer(string id)
        {
            Customer customer = this.DbContext.Customers.Find(id);
            return customer;
        }

        public void SaveCustomer(Customer customer)
        {
            this.DbContext.Customers.Add(customer);
            this.DbContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            this.DbContext.Customers.AddOrUpdate(customer);
            this.DbContext.SaveChanges();
        }

        public void DeleteCustomer(string id)
        {
            Customer customer = this.DbContext.Customers.Find(id);
            if (customer == null)
            {
                throw new Exception($"Customer with ID: {id} not found, Delete failed");
            }

            this.DbContext.Customers.Remove(customer);
            this.DbContext.SaveChanges();
        }
    }
}