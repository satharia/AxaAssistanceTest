using AxaAssistanceTest.Models.ApplicationLogic;
using AxaAssistanceTest.Models.ApplicationLogic.Exceptions;
using AxaAssistanceTest.Models.DomainLogic.Service;
using AxaAssistanceTest.Models.Entities.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AxaAssistanceTest.Controllers
{
    public class ReservationsController : ApiController
    {
        private ReservationService ReservationService;

        public ReservationsController() { }

        public ReservationsController(ReservationService ReservationService) {
            this.ReservationService = ReservationService;
        }

        [HttpGet]
        public HttpResponseMessage ListReservations()
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, this.ReservationService.ListReservations());
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new BasicApiResponse { Message = ex.Message });
            }
        }

        [HttpGet]
        public HttpResponseMessage GetReservation(int id)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, this.ReservationService.GetReservation(id));
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
        public HttpResponseMessage CreateReservation([FromBody]Reservation value)
        {
            BasicApiResponse response = new BasicApiResponse();
            try
            {
                this.ReservationService.CreateReservation(value);

                response.Message = "Successfully created the Reservation, this Customer may not open a new one until this is closed";
                response.Data = value;
            }
            catch (ArgumentNullException ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
            catch (UnavailableStateException ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.PreconditionFailed, response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPut]
        public HttpResponseMessage CloseReservation([FromBody]Reservation value)
        {
            BasicApiResponse response = new BasicApiResponse();
            try
            {
                this.ReservationService.CloseReservation(value);

                response.Message = "Successfully closed the Reservation, this Customer may open a new one now";
            }
            catch (ArgumentNullException ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
            catch (EntityNotFoundException ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.NotFound, response);
            }
            catch (UnavailableStateException ex)
            {
                response.Message = ex.Message;
                return this.Request.CreateResponse(HttpStatusCode.PreconditionFailed, response);
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
