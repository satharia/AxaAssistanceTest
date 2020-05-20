using AxaAssistanceTest.Models.ApplicationLogic;
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
        public IEnumerable<Reservation> ListReservations()
        {
            return this.ReservationService.ListReservations();
        }

        [HttpGet]
        public Reservation GetReservation(int id)
        {
            return this.ReservationService.GetReservation(id);
        }

        [HttpPost]
        public BasicApiResponse CreateReservation([FromBody]Reservation value)
        {
            BasicApiResponse response = new BasicApiResponse();
            this.ReservationService.CreateReservation(value);

            response.Message = "Successfully created the Reservation, this Customer may not open a new one until this is closed";
            response.Data = value;
            return response;
        }

        [HttpPut]
        public BasicApiResponse CloseReservation([FromBody]Reservation value)
        {
            BasicApiResponse response = new BasicApiResponse();
            this.ReservationService.CloseReservation(value);

            response.Message = "Successfully closed the Reservation, this Customer may open a new one now";
            return response;
        }
    }
}
