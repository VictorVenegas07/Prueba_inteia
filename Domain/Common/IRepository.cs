using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> additionalFilter = null);
        Task<T> GetByIdAsync(string id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
    }
}
