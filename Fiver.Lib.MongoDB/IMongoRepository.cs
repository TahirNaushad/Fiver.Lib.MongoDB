using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiver.Lib.MongoDB
{
    public interface IMongoRepository<T> where T : MongoEntityBase
    {
        Task<List<T>> GetListAsync();
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        T GetItem(string id);
        Task InsertAsync(T item);
        Task UpdateAsync(string id, T item);
        Task DeleteAsync(string id);
    }
}