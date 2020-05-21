using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AxaAssistanceTest.Models.Entities.Books;
using AxaAssistanceTest.Models.Entities.Customers;
using Newtonsoft.Json;

namespace AxaAssistanceTest.Models.Entities.Reservations
{
    /// <summary>
    /// Entity class representing a reservation of Books that a Customer withdraws from a library.
    /// </summary>
    public class Reservation : AuditEntity
    {
        [Key]
        public int? Id { get; set; }
        public DateTime? ReservationDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string CustomerId { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ReservedBook> ReservedBooks { get; set; }

        public Reservation() : base() { }
    }
}