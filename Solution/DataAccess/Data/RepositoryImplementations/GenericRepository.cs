using DataAccess.Data.RepositoryInterfaces;
using DataAccess.Entities;

namespace DataAccess.Data.RepositoryImplementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> IGenericRepository<T>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<T> IGenericRepository<T>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
