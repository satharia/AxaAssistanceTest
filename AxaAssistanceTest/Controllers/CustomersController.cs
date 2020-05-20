using AxaAssistanceTest.Models.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AxaAssistanceTest.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        public IEnumerable<Customer> List()
        {
            return new List<Customer>();
        }

        [HttpGet]
        public Customer Get(string id)
        {
            return new Customer();
        }
        [HttpPost]
        public void Post([FromBody]Customer value)
        {
        }

        [HttpPut]
        public void Put(string id, [FromBody]Customer value)
        {
        }

        [HttpDelete]
        public void Delete(string id)
        {
        }
    }
}
