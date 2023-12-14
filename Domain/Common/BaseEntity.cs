using MongoDB.Bson;

namespace Domain.Common
{
    public class BaseEntity
    {
        public virtual ObjectId Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DateofElimination { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public void SetDelete() => DateofElimination = DateTime.UtcNow;
        public void SetModified() => DateModified = DateTime.UtcNow;
        public void SetCreated() => DateCreated = DateTime.UtcNow;


    }
}
