using NTNP.Infratructure.Interfaces;
using NTNP.Infratructure.Repositories.User;

namespace NTNP.Infratructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbFactory _dbFactory;

        public IUserRepository UserRepository { get; }
        public UnitOfWork(DbFactory dbFactory, IUserRepository userRepository)
        {
            _dbFactory = dbFactory;
            UserRepository = userRepository;
        }
        public Task<int> CommitAsync() => _dbFactory.DbContext.SaveChangesAsync();
    }
}
