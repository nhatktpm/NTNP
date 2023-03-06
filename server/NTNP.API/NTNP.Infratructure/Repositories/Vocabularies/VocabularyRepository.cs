using LinqKit;
using NTNP.Infratructure.Helpers;
using NTNP.Infratructure.Helpers.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNP.Infratructure.Repositories.Vocabularies
{
    public class VocabularyRepository : Repository<EFCore.Models.Vocabularies.Vocabulary>, IVocabularyRepository
    {
        public VocabularyRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
        public List<EFCore.Models.Vocabularies.Vocabulary> ForPage(ListBaseRequestModel model)
        {
            int skip = model.Reload ? 0 : (model.Page - 1) * model.Limit;
            ExpressionStarter<EFCore.Models.Vocabularies.Vocabulary> predicate = PredicateBuilder.New<EFCore.Models.Vocabularies.Vocabulary>();
            predicate.And(x => CommonFunctions.NotMatch(x, model.Keys, model.SearchKey));
            List<EFCore.Models.Vocabularies.Vocabulary> results = DbSet.Where(predicate)
                                                                       .OrderByDescending(x => x.Name).Skip(skip).Take(model.Limit).ToList();
            return results;
        }

        public bool IsNameExistById(string id, string name)
        {
            return DbSet.Any(x => string.Equals(x.Name.ToLower(), name.ToLower().Trim()) && !string.Equals(x.Id, id));
        }
    }
}
