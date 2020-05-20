using AxaAssistanceTest.Models.DomainLogic.Service;
using AxaAssistanceTest.Models.Entities.Customers;
using System.Collections.Generic;
using System.Web.Http;

namespace AxaAssistanceTest.Controllers
{
    public class CustomersController : ApiController
    {
        private CustomerService CustomerService;

        public CustomersController() { }

        public CustomersController(CustomerService CustomerService) {
            this.CustomerService = CustomerService;
        }

        [HttpGet]
        public IEnumerable<Customer> List()
        {
            return this.CustomerService.ListCustomers();
        }

        [HttpGet]
        public Customer Get(string id)
        {
            return this.CustomerService.GetCustomer(id);
        }

        [HttpPost]
        public void Post([FromBody]Customer value)
        {
            this.CustomerService.SaveCustomer(value);
        }

        [HttpPut]
        public void Put([FromBody]Customer value)
        {
            this.CustomerService.UpdateCustomer(value);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            this.CustomerService.DeleteCustomer(id);
        }
    }
}
