using MongoDB.Driver;

namespace Domain.Context
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>();
    }
}
