using MongoCore.Repository.Context;
using MongoCore.Repository.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoCore.Repository.Implementation
{
    public class MongoRepository<T> : IMongoRepository where T : MongoDbContext
    {
        private readonly T _context;

        public MongoRepository(T context)
        {
            _context = context;
        }

        public async Task<TCollection> GetById<TCollection>(string id)
        {
            return await _context.GetCollection<TCollection>()
                .Find(new BsonDocument("_id", id))
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<TCollection>> GetAll<TCollection>()
        {
            return await _context.GetCollection<TCollection>()
                .Find(f => true)
                .ToListAsync();
        }

        public async Task<ICollection<TCollection>> GetAll<TCollection>(FilterDefinition<TCollection> filter)
        {
            return await _context.GetCollection<TCollection>()
                .Find(filter)
                .ToListAsync();
        }

        public async Task<long> GetCount<TCollection>()
        {
            return await _context.GetCollection<TCollection>()
                .EstimatedDocumentCountAsync();
        }

        public async Task<bool> Exists<TCollection>(string id)
        {
            var obj = await _context.GetCollection<TCollection>()
                .Find(new BsonDocument("_id", id))
                .FirstOrDefaultAsync();

            return obj != null;
        }

        public async Task Create<TCollection>(TCollection entity) where TCollection : class
        {
            await _context.GetCollection<TCollection>()
                .InsertOneAsync(entity);
        }

        public async Task Update<TCollection>(object id, TCollection entity) where TCollection : class
        {
            await _context.GetCollection<TCollection>()
                .ReplaceOneAsync(Builders<TCollection>.Filter.Eq("_id", id), entity, new UpdateOptions { IsUpsert = true });
        }

        public async Task Delete<TCollection>(object id) where TCollection : class
        {
            await _context.GetCollection<TCollection>().DeleteOneAsync(
                    Builders<TCollection>.Filter.Eq("_id", id));
        }
    }
}
