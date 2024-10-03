﻿using DataAccess.Data.RepositoryInterfaces;
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
        
    public async Task Create(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        await _context.Set<T>().AddAsync(entity);
        await SaveChangedAsync();
    }

    public void Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Set<T>().Remove(entity);
    }

    public async void Delete(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
        {
            throw new  ArgumentOutOfRangeException();
        }
        Delete(entity);
    }

    //public void Update(T entity)
    //{
    //    throw new NotImplementedException();
    //}

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
