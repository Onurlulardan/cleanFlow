using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cleanFlow.Repositories.RoleRepository;
using cleanFlow.Dtos.RoleDtos;

namespace cleanFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var result = await _roleRepository.GetAllRoles();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRoleById(int roleId)
        {
            try
            {
                var result = await _roleRepository.GetRoleById(roleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            try
            {
                await _roleRepository.CreateRole(createRoleDto);
                return Ok("Rol başarılı bir şekilde eklendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{roleId}")]
        public async Task<IActionResult> UpdateRole(int roleId, UpdateRoleDto updateRoleDto)
        {
            try
            {
                await _roleRepository.UpdateRole(roleId, updateRoleDto);
                return Ok("Rol başarılı bir şekilde güncellendi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(int[] roleId)
        {
            try
            {
                await _roleRepository.DeleteRole(roleId);
                return Ok("Rol başarılı bir şekilde silindi!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
