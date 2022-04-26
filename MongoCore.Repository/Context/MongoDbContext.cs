using Microsoft.Extensions.Options;
using MongoCore.Domain.Assets;
using MongoCore.Domain.Model;
using MongoDB.Driver;

namespace MongoCore.Repository.Context
{
    public class MongoDbContext
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _db;

        public MongoDbContext(IOptions<DbSettings> settings)
        {
            _client = new MongoClient(settings.Value.ConnectionString);
            _db = _client.GetDatabase(settings.Value.Database);
        }

        public MongoDbContext(string connection, string database)
        {
            _client = new MongoClient(connection);
            _db = _client.GetDatabase(database);
        }

        public IMongoClient Client()
        {
            return _client;
        }

        public IMongoDatabase Database()
        {
            return _db;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _db.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<Blog> Blogs()
        {
            return _db.GetCollection<Blog>("Blog");
        }
    }
}
