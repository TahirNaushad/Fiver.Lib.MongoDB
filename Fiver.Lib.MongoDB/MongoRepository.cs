using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiver.Lib.MongoDB
{
    public sealed class MongoRepository<T> : IMongoRepository<T> where T : MongoEntityBase
    {
        #region " Public "

        public MongoRepository(MongoSettings settings)
        {
            this.settings = settings;
            Init();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await collection.AsQueryable().ToListAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return await collection.AsQueryable()
                                   .Where(predicate)
                                   .ToListAsync();
        }

        public T GetItem(string id)
        {
            return collection.Find(doc => doc.Id == id).FirstOrDefault();
        }

        public async Task InsertAsync(T item)
        {
            await collection.InsertOneAsync(item);
        }

        public async Task UpdateAsync(string id, T item)
        {
            await collection.ReplaceOneAsync(doc => doc.Id == id, item);
        }

        public async Task DeleteAsync(string id)
        {
            await collection.DeleteOneAsync(doc => doc.Id == id);
        }

        #endregion

        #region " Private "

        private MongoSettings settings;
        private IMongoCollection<T> collection;

        private void Init()
        {
            collection = new MongoClient(settings.ConnectionString)
                                .GetDatabase(settings.DatabaseName)
                                .GetCollection<T>(settings.CollectionName);
        }

        #endregion
    }
}
