using Microsoft.EntityFrameworkCore;
using NTNP.EFCore.Context;

namespace NTNP.Infratructure
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private readonly Func<NTNPContext> _dbContextFactory;
        private DbContext _dbContext;
        public DbContext DbContext => _dbContext ??= _dbContextFactory.Invoke();

        public DbFactory(Func<NTNPContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
