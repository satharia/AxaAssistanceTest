using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AxaAssistanceTest.Models.Entities.Reservations
{
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