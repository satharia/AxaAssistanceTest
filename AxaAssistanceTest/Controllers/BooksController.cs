using AxaAssistanceTest.Models.ApplicationLogic;
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
        public BasicApiResponse Post([FromBody]Book value)
        {
            BasicApiResponse response = new BasicApiResponse();
            this.BookService.SaveBook(value);

            response.Message = "Successfully saved the Book object";
            response.Data = value;
            return response;
        }

        [HttpPut]
        public BasicApiResponse Put([FromBody]Book value)
        {
            BasicApiResponse response = new BasicApiResponse();
            this.BookService.UpdateBook(value);

            response.Message = "Successfully updated the Book object";
            response.Data = value;
            return response;
        }

        [HttpDelete]
        public BasicApiResponse Delete(long id)
        {
            BasicApiResponse response = new BasicApiResponse();
            this.BookService.DeleteBook(id);

            response.Message = "Successfully deleted the Book object";
            return response;
        }
    }
}
