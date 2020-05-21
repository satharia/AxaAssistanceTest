using AxaAssistanceTest.Models.ApplicationLogic;
using AxaAssistanceTest.Models.ApplicationLogic.Exceptions;
using AxaAssistanceTest.Models.DomainLogic.Service;
using AxaAssistanceTest.Models.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage List()
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, this.CustomerService.ListCustomers());
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new BasicApiResponse { Message = ex.Message });
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, this.CustomerService.GetCustomer(id));
            }
            catch (EntityNotFoundException ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, new BasicApiResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new BasicApiResponse { Message = ex.Message });
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Customer value)
        {
            BasicApiResponse response = new BasicApiResponse();
            try
            {
                this.CustomerService.SaveCustomer(value);

                response.Message = ResponseMessages.SaveCustomerOk;
                response.Data = value;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]Customer value)
        {
            BasicApiResponse response = new BasicApiResponse();
            try
            {
                this.CustomerService.UpdateCustomer(value);

                response.Message = ResponseMessages.UpdateCustomerOk;
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
        public HttpResponseMessage Delete(string id)
        {
            BasicApiResponse response = new BasicApiResponse();
            try
            {
                this.CustomerService.DeleteCustomer(id);

                response.Message = ResponseMessages.DeleteCustomerOk;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
