using DataAccess.Data.Specifications;
using DataAccess.Entities;

namespace DataAccess.Data.RepositoryInterfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();

    Task<T?> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);


    // create
    Task<T> CreateAsync(T entity);

    // delete
    Task DeleteAsync(T entity);
    Task DeleteAsync(int id);

    // update
    // Get by Id
    // Do the object mappings to entity
    // call SaveChangedAsync()
    Task UpdateAsync(T entity);

    // Save / Commit / Update
    Task SaveChangedAsync();
}
