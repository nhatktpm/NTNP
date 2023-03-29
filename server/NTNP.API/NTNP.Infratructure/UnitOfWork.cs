using NTNP.Infratructure.Interfaces;
using NTNP.Infratructure.Repositories.User;
using NTNP.Infratructure.Repositories.Vocabularies;

namespace NTNP.Infratructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbFactory _dbFactory;

        public IUserRepository UserRepository { get; }
        public IVocabularyRepository VocabularyRepository { get; }
        public UnitOfWork(DbFactory dbFactory, IUserRepository userRepository,
               IVocabularyRepository vocabularyRepository)
        {
            _dbFactory = dbFactory;
            UserRepository = userRepository;
            VocabularyRepository = vocabularyRepository;
        }
        public Task<int> CommitAsync() => _dbFactory.DbContext.SaveChangesAsync();
        public int Commit() => _dbFactory.DbContext.SaveChanges();
    }
}
