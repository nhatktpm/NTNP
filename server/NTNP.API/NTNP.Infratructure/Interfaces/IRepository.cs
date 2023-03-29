using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NTNP.Infratructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> FindAsync(int id);
        IQueryable<T> GetQuery();
        IQueryable<TK> Search<TK>(IQueryable<TK> query, IEnumerable<string> propertyNames, string keyword);
        T Find(int id);
        Task<EntityEntry<T>> AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void HardDelete(T etity);
    }
}
