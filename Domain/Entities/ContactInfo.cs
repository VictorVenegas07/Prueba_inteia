namespace Domain.Entities
{
    public class ContactInfo
    {
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public void Update(string? contactName, string contactEmail)
        {
            if(contactName is not null && !contactName.Equals(ContactName) && !contactName.Equals("")) { ContactName = contactName;  }
            if (contactEmail is not null && !contactEmail.Equals(ContactEmail) && !contactEmail.Equals("")) { ContactEmail = contactEmail;  }
        }
    }

}
