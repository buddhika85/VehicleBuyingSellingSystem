using DataAccess.Data.RepositoryInterfaces;
using DataAccess.Data.Specifications;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.RepositoryImplementations;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    // Get
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T?> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }
        
    public async Task CreateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        await _context.Set<T>().AddAsync(entity);
        await SaveChangedAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        if (await GetByIdAsync(entity.Id) == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} with id {entity.Id} is unavailable for update");
        }
        _context.Entry(entity).State = EntityState.Modified;
        await SaveChangedAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Set<T>().Remove(entity);
        await SaveChangedAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
        {
            throw new  ArgumentOutOfRangeException();
        }
        await DeleteAsync(entity);
    }

    public async Task SaveChangedAsync()
    {
        await _context.SaveChangesAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(
            _context.Set<T>().AsQueryable(),                // T type DB table as a queryable
            spec);
    }
}
