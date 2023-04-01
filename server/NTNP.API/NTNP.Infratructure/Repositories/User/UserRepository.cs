using Microsoft.EntityFrameworkCore;


namespace NTNP.Infratructure.Repositories.User
{
    public class UserRepository : Repository<EFCore.Models.Users.User>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }

        public async Task<EFCore.Models.Users.User> GetByUserName(string userName)
        {
            return await DbSet.FirstOrDefaultAsync(x => string.Equals(x.Name, userName));
        }
    }
}
