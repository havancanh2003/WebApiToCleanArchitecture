namespace WebApiToCleanArchitecture.Application.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; } 
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
