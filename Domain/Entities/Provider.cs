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
        [BsonElement("Contac")]

        public ContactInfo ContactInfo { get; set; }

    }
}
