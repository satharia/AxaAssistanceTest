using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AxaAssistanceTest.Models.Entities.Reservations
{
    /// <summary>
    /// Entity class representing a relationship between a reservation and the Books withdrawn in it.
    /// </summary>
    public class ReservedBook : AuditEntity
    {
        [Key]
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int BookId { get; set; }

        [JsonIgnore]
        public virtual Reservation Reservation { get; set; }

        public ReservedBook() : base() { }
    }
}