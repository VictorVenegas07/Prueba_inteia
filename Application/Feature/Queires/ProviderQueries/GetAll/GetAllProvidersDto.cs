namespace Application.Feature.Queires.ProviderQueries.GetAll
{
    public class GetAllProvidersDto
    {
        public string Id { get; set; }
        public int NIT { get; set; }
        public Company Company { get; set; }
        public Contact Contact { get; set; }
        public bool IsActive { get; set; }
    }

    public class Company
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
    }

    public class Contact
    {
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
    }
}
