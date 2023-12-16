using Domain.Common;
using Domain.Common.Interfaces;
using Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoDbContext _dbContext;
        private readonly IMongoCollection<T> _collection;
        private readonly FilterDefinition<T> _globalFilter;
        public Repository(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
            _collection = _dbContext.GetCollection<T>();
            _globalFilter = Builders<T>.Filter.Eq(e => e.IsDeleted, false);
        }


        public async Task CreateAsync(T entity)
        {
            entity.SetCreated();
            await _collection.InsertOneAsync(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            entity.SetModified();
            await _collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
        }
        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq(e => e.Id, ObjectId.Parse(id));
            var update = Builders<T>.Update.Set(e => e.IsDeleted, true).Set(e => e.DateofElimination, DateTime.UtcNow);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> additionalFilter = null)
        {
            var combinedFilter = _globalFilter;
            if (additionalFilter != null)
            {
                combinedFilter &= Builders<T>.Filter.Where(additionalFilter);
            }

            return await _collection.Find(combinedFilter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq(e => e.Id, ObjectId.Parse(id)) & _globalFilter;
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
        {
            var combinedFilter = _globalFilter & filter;
            return await _collection.Find(combinedFilter).FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
        {
            var combinedFilter = _globalFilter & filter;
            var count = await _collection.CountDocumentsAsync(combinedFilter);
            return count > 0;
        }
    }
}
