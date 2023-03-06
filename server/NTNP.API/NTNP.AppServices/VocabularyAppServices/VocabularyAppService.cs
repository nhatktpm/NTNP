using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NTNP.AppServices.Common.Dtos.ResponseDto;
using NTNP.AppServices.VocabularyAppServices.Dtos.RequestDtos;
using NTNP.EFCore.Models.Vocabularies;
using NTNP.Infratructure.Helpers.Dtos;
using NTNP.Infratructure.Interfaces;

namespace NTNP.AppServices.VocabularyAppServices
{
    public class VocabularyAppService : IVocabularyAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VocabularyAppService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseComonDto> AddAsync(CreateVocabularyRequest requestDto)
        {
            ResponseComonDto response = new ResponseComonDto();

            Vocabulary vocabulary = _mapper.Map<CreateVocabularyRequest, Vocabulary>(requestDto);
          
            await _unitOfWork.VocabularyRepository.AddAsync(vocabulary);
            await _unitOfWork.CommitAsync();

            response.Success= true;
            response.Data = vocabulary;
            return response;
        }

        public async Task<ResponseComonDto> DeleteAsync(DeleteVocabularyRequest requestDto)
        {
            ResponseComonDto response = new ResponseComonDto();
            Vocabulary vocabulary = await _unitOfWork.VocabularyRepository.FindAsync(requestDto.Id);
            if (vocabulary != null)
            {
                vocabulary.Deleted = true;
                await _unitOfWork.CommitAsync();
                
                response.Success= true;
                response.Data = vocabulary;
                return response;
            }
            return response;
        }

        public async Task<ResponseComonDto> GetAsync(int id)
        {
            ResponseComonDto response = new ResponseComonDto();
            Vocabulary vocabulary = await _unitOfWork.VocabularyRepository.FindAsync(id);
            if (vocabulary != null)
            {
                response.Success = true;
                response.Data = vocabulary;
            }
            return response;
        }

        public async Task<ResponseComonDto> GetListAsync()
        {
            ResponseComonDto response = new ResponseComonDto();
            var listVocabulary = await _unitOfWork.VocabularyRepository.GetQuery().ToListAsync();

            response.Data = listVocabulary;
            response.Success = true;
            return response;
        }

        public async Task<List<ComboboxCommonResponseDto>> GetCombobox()
        {
            var vocabularyCombobox = await _unitOfWork.VocabularyRepository.GetQuery().Select(x => new ComboboxCommonResponseDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return vocabularyCombobox;
        }

        public async Task<ResponseComonDto> UpdateAsync(UpdateVocabularyRequest requestDto)
        {
            ResponseComonDto response = new ResponseComonDto();
            Vocabulary vocabulary = await _unitOfWork.VocabularyRepository.FindAsync(requestDto.Id);
            _mapper.Map(requestDto, vocabulary);
            _unitOfWork.VocabularyRepository.Update(vocabulary);
            await _unitOfWork.CommitAsync();

            response.Data = vocabulary;
            response.Success = true;
            return response;
        }
    }
}
