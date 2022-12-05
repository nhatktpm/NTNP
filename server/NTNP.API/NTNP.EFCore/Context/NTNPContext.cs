using System.Data.Entity;

namespace NTNP.EFCore.Context
{
    public class NTNPContext : DbContext
    {
        private readonly string _connectionString;
        public NTNPContext(string connectionString)
        {
            _connectionString = connectionString;
        }


    }
}
