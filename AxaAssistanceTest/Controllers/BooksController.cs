using AxaAssistanceTest.Models.ApplicationLogic;
using AxaAssistanceTest.Models.ApplicationLogic.Exceptions;
using AxaAssistanceTest.Models.DomainLogic.Service;
using AxaAssistanceTest.Models.Entities.Books;
using System;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage List()
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, this.BookService.ListBooks());
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new BasicApiResponse { Message = ex.Message });
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(long id)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, this.BookService.GetBook(id));
            }
            catch(EntityNotFoundException ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, new BasicApiResponse { Message = ex.Message });
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new BasicApiResponse { Message = ex.Message });
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Book value)
        {
            BasicApiResponse response = new BasicApiResponse();
            try
            {
                this.BookService.SaveBook(value);

                response.Message = "Successfully saved the Book object";
                response.Data = value;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]Book value)
        {
            BasicApiResponse response = new BasicApiResponse();
            try
            {
                this.BookService.UpdateBook(value);

                response.Message = "Successfully updated the Book object";
                response.Data = value;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(long id)
        {
            BasicApiResponse response = new BasicApiResponse();
            try
            {
                this.BookService.DeleteBook(id);

                response.Message = "Successfully deleted the Book object";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
