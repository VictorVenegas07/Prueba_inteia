using Domain.Common;
using Infrastructure.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoDbContext _dbContext;
        private readonly IMongoCollection<T> _collection;

        public Repository(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
            _collection = _dbContext.GetCollection<T>();
        }

        private bool disposedValue;

        public async Task Create(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await _collection.Find(e => e.Id.ToString() == id).FirstOrDefaultAsync();
        }

        public Task SoftDelete(string id)
        {
            throw new NotImplementedException();
        }
    
    }
}
