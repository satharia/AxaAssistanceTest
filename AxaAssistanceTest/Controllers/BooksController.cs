using AxaAssistanceTest.Models.DomainLogic.Service;
using AxaAssistanceTest.Models.Entities.Books;
using System.Collections.Generic;
using System.Web.Http;

namespace AxaAssistanceTest.Controllers
{
    public class BooksController : ApiController
    {
        private BookService BookService;

        public BooksController() { }

        public BooksController(BookService BookService) {
            this.BookService = BookService;
        }

        [HttpGet]
        public IEnumerable<Book> List()
        {
            return this.BookService.ListBooks();
        }

        [HttpGet]
        public Book Get(long id)
        {
            return this.BookService.GetBook(id);
        }

        [HttpPost]
        public void Post([FromBody]Book value)
        {
            this.BookService.SaveBook(value);
        }

        [HttpPut]
        public void Put([FromBody]Book value)
        {
            this.BookService.UpdateBook(value);
        }

        [HttpDelete]
        public void Delete(long id)
        {
            this.BookService.DeleteBook(id);
        }
    }
}
