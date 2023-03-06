using FluentValidation;
using NTNP.AppServices.VocabularyAppServices.Dtos.RequestDtos;
using NTNP.Infratructure.Interfaces;

namespace NTNP.AppServices.VocabularyAppServices.Validation
{
    public class CreateVocabularyValidation : AbstractValidator<CreateVocabularyRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateVocabularyValidation(IUnitOfWork unitOfWork)
        {

        }
    }
}
