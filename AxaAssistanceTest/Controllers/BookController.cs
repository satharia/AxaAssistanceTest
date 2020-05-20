using AxaAssistanceTest.Models.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AxaAssistanceTest.Controllers
{
    public class BookController : ApiController
    {
        [HttpGet]
        public IEnumerable<Book> List()
        {
            return new List<Book>();
        }

        [HttpGet]
        public Book Get(string id)
        {
            return new Book();
        }

        [HttpPost]
        public void Post([FromBody]Book value)
        {
        }

        [HttpPut]
        public void Put(string id, [FromBody]Book value)
        {
        }

        [HttpDelete]
        public void Delete(string id)
        {
        }
    }
}
