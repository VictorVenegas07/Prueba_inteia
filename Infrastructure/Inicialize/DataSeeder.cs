using Domain.Common.Security;
using Domain.Entities;
using Infrastructure.Context;
using MongoDB.Driver;

namespace Infrastructure.Inicialize
{
    public class DataSeeder
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<User> _collection;
        private readonly IPasswordHasher _passwordHasher;

        public DataSeeder(string connectionString, string databaseName, IPasswordHasher passwordHasher)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
            _collection = _database.GetCollection<User>("User");
            _passwordHasher = passwordHasher;
        }
        public void SeedData()
        {
            //if (!_collection.AsQueryable().Any())
            //{
            //    var users = new List<User>()
            //    {
            //        new User { UserName = "vvenegas", password = _passwordHasher.HashPassword("victor2301") },
            //    };
            //    _collection.InsertMany(users);
            //}
        }
    }
}
