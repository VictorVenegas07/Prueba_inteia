using Domain.Common;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public byte[] password { get; set; } = new byte[32];
    }
}
