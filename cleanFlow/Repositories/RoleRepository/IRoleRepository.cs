using cleanFlow.Dtos.RoleDtos;

namespace cleanFlow.Repositories.RoleRepository
{
    public interface IRoleRepository
    {
        Task<List<ResultRoleDto>> GetAllRoles();
        Task<List<ResultRoleDto>> GetRoleById(int roleid);
        Task CreateRole(CreateRoleDto createRoleDto);
        Task UpdateRole(int roleid, UpdateRoleDto updateRoleDto);
        Task DeleteRole(int[] roleid);
    }
}
