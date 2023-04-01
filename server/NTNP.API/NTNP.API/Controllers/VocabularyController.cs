using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTNP.AppServices.VocabularyAppServices;
using NTNP.AppServices.VocabularyAppServices.Dtos.RequestDtos;
using NTNP.EFCore.Models.Users;

namespace NTNP.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VocabularyController : Controller
    {
        private readonly IVocabularyAppService _vocabularyAppService;
        public VocabularyController(IVocabularyAppService vocabularyAppService)
        {
            _vocabularyAppService = vocabularyAppService;
        }

        [HttpPost]
        [Route("add-vocabulary")]
        public async Task<ActionResult> AddnAsync([FromBody] CreateVocabularyRequest body)
        {
            var response = await _vocabularyAppService.AddAsync(body);
            return Ok(response);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("get-vocabulary")]
        public async Task<ActionResult> GetAsync([FromBody] GetVocabularyRequest body)
        {
            var response = await _vocabularyAppService.GetAsync(body.Id);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("get-list-vocabulary")]
        public async Task<ActionResult> GetListAsync()
        {
            var response = await _vocabularyAppService.GetListAsync();
            return Ok(response);
        }

        [HttpPost]
        [Route("delete-vocabulary")]
        public async Task<ActionResult> DeleteAsync([FromBody] DeleteVocabularyRequest body)
        {
            var response = await _vocabularyAppService.DeleteAsync(body);
            return Ok(response);
        }
        [Authorize]
        [HttpPost]
        [Route("get-combobox-vocabulary")]
        public async Task<ActionResult> GetComboboxAsync()
        {
            var response = await _vocabularyAppService.GetCombobox();
            return Ok(response);
        }

        [HttpPost]
        [Route("list-vocabulary")]
        public async Task<ActionResult> GetListAsync([FromBody] CreateVocabularyRequest body)
        {
            var response = await _vocabularyAppService.AddAsync(body);
            return Ok(response);
        }

        [HttpPost]
        [Route("update-vocabulary")]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateVocabularyRequest body)
        {
            var response = await _vocabularyAppService.UpdateAsync(body);
            return Ok(response);
        }

        [HttpPost]
        [Route("hard-delete-vocabulary")]
        public ActionResult HardDelete([FromBody] DeleteVocabularyRequest body)
        {
            var response = _vocabularyAppService.HardDelete(body);
            return Ok(response);
        }
    }
}
