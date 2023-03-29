using FluentValidation;
using NTNP.AppServices.VocabularyAppServices.Dtos.RequestDtos;
using NTNP.Infratructure.Interfaces;

namespace NTNP.AppServices.VocabularyAppServices.Validation
{
    public class UpdateVocabularyValidation : AbstractValidator<UpdateVocabularyRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateVocabularyValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Name).NotNull().NotEmpty().Must(IsNotDuplicateName).WithMessage("Name already exist");

        }
        private bool IsNotDuplicateName(UpdateVocabularyRequest dto, string name)
        {
            bool isValidNewName = _unitOfWork.VocabularyRepository.IsNameExistById(dto.Id, dto.Name);
            return !isValidNewName;
        }
    }
}
