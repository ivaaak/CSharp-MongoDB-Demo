using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoCore.Repository.Interface
{
    public interface IMongoRepository
    {
        //crud
        Task Create<TCollection>(TCollection entity) where TCollection : class;

        Task<TCollection> GetById<TCollection>(string id);
        Task<ICollection<TCollection>> GetAll<TCollection>();
        Task<ICollection<TCollection>> GetAll<TCollection>(FilterDefinition<TCollection> filter);

        Task Update<TCollection>(object id, TCollection entity) where TCollection : class;

        Task Delete<TCollection>(object id) where TCollection : class;


        //debug
        Task<long> GetCount<TCollection>();
        Task<bool> Exists<TCollection>(string id);
    }
}
