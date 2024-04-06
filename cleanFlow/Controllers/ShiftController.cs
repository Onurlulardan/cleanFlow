using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cleanFlow.Dtos.ShiftDtos;
using cleanFlow.Repositories.ShiftRepository;
using Microsoft.AspNetCore.Authorization;

namespace cleanFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepository;
        public ShiftController(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShift()
        {
            try
            {
                var result = await _shiftRepository.GetAllShift();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{shiftid}")]
        public async Task<IActionResult> GetShiftById(int shiftid)
        {
            try
            {
                var result = await _shiftRepository.GetShiftById(shiftid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateShift(CreateShiftDto createShiftDto)
        {
            try
            {
                await _shiftRepository.CreateShift(createShiftDto);
                return Ok("Shift başarılı bir şekilde eklendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{shiftid}")]
        public async Task<IActionResult> UpdateShift(int shiftid, UpdateShiftDto updateShiftDto)
        {
            try
            {
                await _shiftRepository.UpdateShift(shiftid ,updateShiftDto);
                return Ok("Shift başarılı bir şekilde güncellendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShift(int[] shiftid)
        {
            try
            {
                await _shiftRepository.DeleteShift(shiftid);
                return Ok("Shift başarılı bir şekilde silindi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
