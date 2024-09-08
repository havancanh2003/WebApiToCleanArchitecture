namespace WebApiToCleanArchitecture.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }  // Auto-increment
        public string FullName { get; set; }
        public bool Gender  { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
