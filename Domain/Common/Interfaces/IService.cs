namespace Domain.Common.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task<string> Create(T entity);
        Task Update(string id, T entity);
        Task Delete(string id);
    }
}
