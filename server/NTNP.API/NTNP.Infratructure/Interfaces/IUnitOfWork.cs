using NTNP.Infratructure.Repositories.User;
using NTNP.Infratructure.Repositories.Vocabularies;

namespace NTNP.Infratructure.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IVocabularyRepository VocabularyRepository { get; } 

        Task<int> CommitAsync();
    }
}
