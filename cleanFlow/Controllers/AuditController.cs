using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cleanFlow.Repositories.AuditRepository;
using cleanFlow.Dtos.AuditDtos;

namespace cleanFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditRepository _auditRepository;
        public AuditController(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAudits()
        {
            try
            {
                var result = await _auditRepository.GetAllAudit();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{auditId}")]
        public async Task<IActionResult> GetAuditById(int auditId)
        {
            try
            {
                var result = await _auditRepository.GetAuditById(auditId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAudit([FromBody] CreateAuditDto createAuditDto)
        {
            try
            {
                await _auditRepository.CreateAudit(createAuditDto);
                return Ok("Denetçi Eklendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addPersonel")]
        public async Task<IActionResult> AddPersonelToAudit([FromBody] UpdateAuditDto updateAuditDto)
        {
            try
            {
                await _auditRepository.AddPersonelToAudit(updateAuditDto);
                return Ok("Denetçiye Personel Eklendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAudit(int[] auditId)
        {
            try
            {
                await _auditRepository.DeleteAudit(auditId);
                return Ok("Denetçi Silindi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletePersonel")]
        public async Task<IActionResult> DeletePersonelFromAudit(int personelId)
        {
            try
            {
                await _auditRepository.DeletePersonelFromAudit(personelId);
                return Ok("Denetçiden Personel Silindi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
