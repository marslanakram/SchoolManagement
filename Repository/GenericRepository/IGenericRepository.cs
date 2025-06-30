using System.Linq.Expressions;

namespace SchoolManagement.Repository.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        // Basic CRUD
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);           // Bulk add
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);            // Bulk delete
        Task SaveChangesAsync();

        // Extended features

        // Check if any record matches the predicate
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        // Count all or filtered records
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        // Pagination with filtering and sorting
        Task<IEnumerable<T>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null,
            bool asNoTracking = true
        );
        // Get first or default with optional includes
        Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            string? includeProperties = null,
            bool asNoTracking = true
        );
    }
}
