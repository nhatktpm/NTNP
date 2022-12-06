using NTNP.Infratructure.Repositories.User;

namespace NTNP.Infratructure.Interfaces
{
    public interface IUnitOfWork
    {
         IUserRepository UserRepository { get; }
        Task<int> CommitAsync();
    }
}
