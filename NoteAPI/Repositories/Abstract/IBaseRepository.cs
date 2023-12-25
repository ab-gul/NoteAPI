using NoteAPI.Domain;

namespace NoteAPI.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : Base
    {
       
        Task<List<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>>? projection = null);
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<int> DeleteAsync(Guid id);
        //Task SaveAsync();


    }
}
