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
        public void CreateReservation([FromBody]Reservation value)
        {
            this.ReservationService.CreateReservation(value);
        }

        [HttpPut]
        public void CloseReservation([FromBody]Reservation value)
        {
            this.ReservationService.CloseReservation(value);
        }
    }
}
