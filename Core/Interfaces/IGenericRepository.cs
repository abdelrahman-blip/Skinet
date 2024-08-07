using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync(); 

        Task<T> GetEntityWithSpec(Ispecification<T> spec);
        Task<IReadOnlyList<T>> ListAsyncSpec(Ispecification<T> spec);

        Task<int> CountAsync(Ispecification<T> spec);

    }
}