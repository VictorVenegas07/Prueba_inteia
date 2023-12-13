using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IService<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task Create(T entity);
        Task SoftDelete(string id);

    }
}
