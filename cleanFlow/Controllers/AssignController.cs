using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cleanFlow.Dtos.AssignDtos;
using cleanFlow.Repositories.AssignRepository;

namespace cleanFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignController : ControllerBase
    {

        private readonly IAssignRepository _assignRepository;

        public AssignController(IAssignRepository assignRepository)
        {
            _assignRepository = assignRepository;
        }

        [HttpGet("{personelId}")]
        public async Task<IActionResult> GetAllAssignByPersonelId(int personelId)
        {
            try
            {
                var result = await _assignRepository.GetAllAssignByPersonelId(personelId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("AssignByAssignId/{assignId}")]
        public async Task<IActionResult> GetAssignById(int assignId)
        {
            try
            {
                var result = await _assignRepository.GetAssignById(assignId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssign(CreateAssignDto createAssignDto)
        {
            try
            {
                await _assignRepository.CreateAssign(createAssignDto);
                return Ok("Atama başarılı!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAssign(UpdateAssignDto updateAssignDto)
        {
            try
            {
                await _assignRepository.UpdateAssign(updateAssignDto);
                return Ok("Atama güncellendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAssign(int[] assignId)
        {
            try
            {
                await _assignRepository.DeleteAssign(assignId);
                return Ok("Atama silindi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
