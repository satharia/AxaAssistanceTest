using AxaAssistanceTest.Models.ApplicationLogic;
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
        public BasicApiResponse Post([FromBody]Customer value)
        {
            BasicApiResponse response = new BasicApiResponse();
            this.CustomerService.SaveCustomer(value);

            response.Message = "Successfully saved the Customer object";
            response.Data = value;
            return response;
        }

        [HttpPut]
        public BasicApiResponse Put([FromBody]Customer value)
        {
            BasicApiResponse response = new BasicApiResponse();
            this.CustomerService.UpdateCustomer(value);

            response.Message = "Successfully updated the Customer object";
            response.Data = value;
            return response;
        }

        [HttpDelete]
        public BasicApiResponse Delete(string id)
        {
            BasicApiResponse response = new BasicApiResponse();
            this.CustomerService.DeleteCustomer(id);

            response.Message = "Successfully deleted the Customer object";
            return response;
        }
    }
}
