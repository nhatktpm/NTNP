using NTNP.AppServices.Common.Dtos.ResponseDto;
using NTNP.AppServices.VocabularyAppServices.Dtos.RequestDtos;
using NTNP.Infratructure.Helpers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNP.AppServices.VocabularyAppServices
{
    public interface IVocabularyAppService
    {
        Task<ResponseComonDto> GetAsync(int id);
        Task<ResponseComonDto> GetListAsync();

        Task<List<ComboboxCommonResponseDto>> GetCombobox();

        Task<ResponseComonDto> AddAsync(CreateVocabularyRequest requestDto);

        Task<ResponseComonDto> UpdateAsync(UpdateVocabularyRequest requestDto);

        Task<ResponseComonDto> DeleteAsync(DeleteVocabularyRequest requestDto);
    }
}
