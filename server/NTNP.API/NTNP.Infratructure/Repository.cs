using NTNP.Infratructure.Interfaces;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace NTNP.Infratructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbFactory _dbFactory;
        private DbSet<T> _dbSet;
        protected DbSet<T> DbSet
        {
            get => _dbSet ??= _dbFactory.DbContext.Set<T>();
        }

        protected Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<T> FindAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public IQueryable<T> GetQuery()
        {
            return DbSet.AsQueryable();
        }
        public IQueryable<TK> Search<TK>(IQueryable<TK> query, IEnumerable<string> propertyNames, string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return query;
            }
            IEnumerable<PropertyInfo> properties = typeof(TK).GetProperties().AsEnumerable();
            ExpressionStarter<TK> predicate = PredicateBuilder.New<TK>();
            foreach (string key in propertyNames)
            {
                PropertyInfo property = properties.FirstOrDefault(p => string.Compare(p.Name.ToLower(), key.ToLower(), StringComparison.Ordinal) == 0);
                if (property != null)
                {
                    predicate = predicate.Or(d => d != null && EF.Functions.Like(EF.Property<string>(d, property.Name), $"%{keyword}%"));
                }
            }
            query = query.AsExpandable().Where(predicate);
            return query;
        }

        public T Find(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<EntityEntry<T>> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            return await DbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
