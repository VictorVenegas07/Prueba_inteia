namespace Domain.Common
{
    public interface IService<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task<string> Create(T entity);
        Task<string> Update(string id,T entity);
        Task<string> Delete(string id);

    }
}
