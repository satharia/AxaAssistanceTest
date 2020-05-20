using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AxaAssistanceTest.Models.Entities.Books;
using AxaAssistanceTest.Models.Entities.Customers;

namespace AxaAssistanceTest.Models.Entities.Reservations
{
    public class Reservation : AuditEntity
    {
        [Key]
        public int? Id { get; set; }
        public DateTime? ReservationDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ReservedBook> ReservedBooks { get; set; }

        public Reservation() : base() { }
    }
}