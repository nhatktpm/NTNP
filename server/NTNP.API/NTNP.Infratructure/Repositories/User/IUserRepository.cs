using NTNP.Infratructure.Interfaces;

namespace NTNP.Infratructure.Repositories.User
{
    public interface IUserRepository : IRepository<EFCore.Models.Users.User>
    {
        public Task<EFCore.Models.Users.User> GetByUserName(string userName);
    }
}
