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
    Task Create(T entity);

    // delete
    void Delete(T entity);
    void Delete(int id);

    // update
    // Get by Id
    // Do the object mappings to entity
    // call SaveChangedAsync()
    //void Update(T entity);

    // Save / Commit / Update
    Task SaveChangedAsync();
}
