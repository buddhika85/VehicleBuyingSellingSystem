using DataAccess.Entities;

namespace DataAccess.Data.RepositoryInterfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
}
