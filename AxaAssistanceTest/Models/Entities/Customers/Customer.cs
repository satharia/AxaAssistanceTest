namespace AxaAssistanceTest.Models.Entities.Customers
{
    public class Customer : AuditEntity
    {
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
    }
}