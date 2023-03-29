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
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Name).NotNull().NotEmpty().Must(IsNameNotExist).WithMessage("Name already exist");

        }

        private  bool IsNameNotExist(string name)
        {
            return ! _unitOfWork.VocabularyRepository.IsNameExist(name);
        }
    }
}
