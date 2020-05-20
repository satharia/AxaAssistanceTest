using System;
using System.Collections.Generic;
using AxaAssistanceTest.Models.Entities.Books;

namespace AxaAssistanceTest.Models.Entities.Reservations
{
    public class Reservation : AuditEntity
    {
        public long? Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string CustomerId { get; set; }
        public List<Book> ReservedBooks { get; set; }
    }
}