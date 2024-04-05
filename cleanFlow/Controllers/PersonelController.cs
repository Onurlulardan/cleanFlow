using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cleanFlow.Dtos.PersonelDtos;
using cleanFlow.Repositories.PersonelRepository;
using Microsoft.AspNetCore.Authorization;

namespace cleanFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelRepository _personelRepository;

        public PersonelController(IPersonelRepository personelRepository)
        {
            _personelRepository = personelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAllPersonels()
        {
            try
            {
                var result = await _personelRepository.getAllPersonels();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonel(CreatePersonelDto createPersonelDto)
        {
            try
            {
                await _personelRepository.CreatePersonel(createPersonelDto);
                return Ok("Personel başarılı bir şekilde eklendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonel(UpdatePersonelDto updatePersonelDto)
        {
            try
            {
                _personelRepository.UpdatePersonel(updatePersonelDto);
                return Ok("Personel Başarılı bir şekilde güncellendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePersonel(int[] personelId)
        {
            try
            {
                _personelRepository.DeletePersonel(personelId);
                return Ok("Personel Başarılı bir şekilde silindi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{personelId}")]
        public async Task<IActionResult> getPersonelById(int personelId)
        {
            try
            {
                var result = await _personelRepository.getPersonelById(personelId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
