using cleanFlow.Repositories.WcRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cleanFlow.Dtos.WcDtos;
using Microsoft.AspNetCore.Authorization;

namespace cleanFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WcController : ControllerBase
    {
        private readonly IWcRepository _wcRepository;

        public WcController(IWcRepository wcRepository)
        {
            _wcRepository = wcRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWc()
        {
            try
            {
                var result = await _wcRepository.GetAllWc();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{wcid}")]
        public async Task<IActionResult> GetWcById(int wcid)
        {
            try
            {
                var result = await _wcRepository.GetWcById(wcid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateWc(CreateWcDto createWcDto)
        {
            try
            {
                await _wcRepository.CreateWc(createWcDto);
                return Ok("WC başarılı bir şekilde eklendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{wcid}")]
        public async Task<IActionResult> UpdateWc(int wcid,UpdateWcDto updateWcDto)
        {
            try
            {
                await _wcRepository.UpdateWc(wcid ,updateWcDto);
                return Ok("WC başarılı bir şekilde güncellendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWc(int[] wcid)
        {
            try
            {
                await _wcRepository.DeleteWc(wcid);
                return Ok("WC başarılı bir şekilde silindi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
