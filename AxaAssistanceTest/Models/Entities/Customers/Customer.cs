using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AxaAssistanceTest.Models.Entities.Reservations;
using Newtonsoft.Json;

namespace AxaAssistanceTest.Models.Entities.Customers
{
    public class Customer : AuditEntity
    {
        [Key]
        public string Id { get; set; }
        public IdTypes IdType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string AddressDetail { get; set; }
        public string ResidenceCity { get; set; }
        public string ResidenceCountry { get; set; }

        [JsonIgnore]
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Customer() : base() { }
    }
}