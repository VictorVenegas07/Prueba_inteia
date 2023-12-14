namespace Domain.Entities
{
    public class CompanyInfo
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }

        public void Update(string? companyName, string? address, string? city, string? department, string? email)
        {
            if (companyName is not null && !companyName.Equals(CompanyName) && !companyName.Equals("")){CompanyName = companyName; }
            if (address is not null && !address.Equals(Address) && !address.Equals("")){Address = address;}
            if (city is not null && !city.Equals(City) && !city.Equals("")){City = city;}
            if (department is not null && !department.Equals(Department) && !department.Equals("")){Department = department;}
            if (email is not null && !email.Equals(Email) && !email.Equals("")){Email = email;}
        }
    }

}
