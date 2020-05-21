using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AxaAssistanceTest.Models.Entities.Reservations;
using Newtonsoft.Json;

namespace AxaAssistanceTest.Models.Entities.Books
{
    /// <summary>
    /// Entity class representing a physical Book from a library.
    /// </summary>
    public class Book : AuditEntity
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime? PublicationDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Book() : base() { }
    }
}