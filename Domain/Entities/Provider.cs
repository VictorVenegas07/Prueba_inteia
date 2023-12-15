using Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Provider: BaseEntity
    {
       
        public int NIT { get; set; }
        [BsonElement("Company")]
        public CompanyInfo CompanyInfo { get; set; }

        public bool IsActive { get; set; }
        [BsonElement("Contact")]

        public ContactInfo ContactInfo { get; set; }

        public void Update(ContactInfo? contactInfo, CompanyInfo? companyInfo, bool? isActive) {
          if(isActive.HasValue && isActive != IsActive) { IsActive = isActive.Value; }
          if(contactInfo is not null) { ContactInfo.Update(contactInfo.ContactName, contactInfo.ContactEmail); }
          if (companyInfo is not null) { CompanyInfo.Update(companyInfo.CompanyName, companyInfo.Address, companyInfo.City, companyInfo.Department, companyInfo.Email);}
        }
        public void SetIsActive() => IsActive = !IsActive;
    }
}
