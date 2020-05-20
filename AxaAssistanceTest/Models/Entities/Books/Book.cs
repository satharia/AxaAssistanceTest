using System;

namespace AxaAssistanceTest.Models.Entities.Books
{
    public class Book : AuditEntity
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}