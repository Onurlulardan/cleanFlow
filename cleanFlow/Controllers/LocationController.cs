using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cleanFlow.Dtos.LocaitonDtos;
using cleanFlow.Repositories.LocaitonRepository;

namespace cleanFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocaitonRepository _locaitonRepository;

        public LocationController(ILocaitonRepository locaitonRepository)
        {
            _locaitonRepository = locaitonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocation()
        {
            try
            {
                var result = await _locaitonRepository.GetAllLocation();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{locationid}")]
        public async Task<IActionResult> GetLocationById(int locationid)
        {
            try
            {
                var result = await _locaitonRepository.GetLocationById(locationid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocaitonDto createLocationDto)
        {
            try
            {
                await _locaitonRepository.CreateLocation(createLocationDto);
                return Ok("Location başarılı bir şekilde eklendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{locationid}")]
        public async Task<IActionResult> UpdateLocation(int locationid, UpdateLocationDto updateLocationDto) 
        {
            try
            {
                await _locaitonRepository.UpdateLocation(locationid, updateLocationDto);
                return Ok("Location başarılı bir şekilde güncellendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(int[] locationid)
        {
            try
            {
                await _locaitonRepository.DeleteLocation(locationid);
                return Ok("Location başarılı bir şekilde silindi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
