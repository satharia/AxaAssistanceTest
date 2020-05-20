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
        [HttpGet]
        public IEnumerable<Reservation> ListReservations()
        {
            return new List<Reservation>();
        }

        [HttpGet]
        public Reservation GetReservation(int id)
        {
            return new Reservation();
        }

        [HttpPost]
        public void OpenReservation([FromBody]Reservation value)
        {
        }

        [HttpPut]
        public void CloseReservation([FromBody]Reservation value)
        {
        }
    }
}
