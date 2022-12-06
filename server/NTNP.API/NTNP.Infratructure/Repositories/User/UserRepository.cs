using NTNP.Infratructure.Interfaces;

namespace NTNP.Infratructure.Repositories.User
{
    public class UserRepository : Repository<EFCore.Models.Users.User>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
