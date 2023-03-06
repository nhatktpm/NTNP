using NTNP.Infratructure.Helpers.Dtos;
using NTNP.Infratructure.Interfaces;

namespace NTNP.Infratructure.Repositories.Vocabularies
{
    public interface IVocabularyRepository : IRepository<EFCore.Models.Vocabularies.Vocabulary>
    {
        public List<EFCore.Models.Vocabularies.Vocabulary> ForPage(ListBaseRequestModel model);

        public bool IsNameExistById(string id, string name);
    }
}
