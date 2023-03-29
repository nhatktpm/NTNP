using FluentValidation;
using NTNP.AppServices.VocabularyAppServices.Dtos.RequestDtos;
using NTNP.Infratructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNP.AppServices.VocabularyAppServices.Validation
{
    public class DeleteVocabularyValidation : AbstractValidator<DeleteVocabularyRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteVocabularyValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Id).NotNull().NotEmpty().Must(IsNotExist).WithMessage("Vocabulary not exist");

        }
        private bool IsNotExist(int id)
        {
            var isExistId = _unitOfWork.VocabularyRepository.Find(id);
            return isExistId != null;
        }
    }
}
