using Dapper;
using cleanFlow.Model.DapperContext;
using cleanFlow.Dtos.RoleDtos;

namespace cleanFlow.Repositories.RoleRepository
{
    public class RoleRepository: IRoleRepository
    {
        private readonly Context _context;
        public RoleRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateRole(CreateRoleDto createRoleDto)
        {
            string query = "INSERT INTO ROLE (ROLENAME) VALUES (@ROLENAME)";

            var parameters = new DynamicParameters();
            parameters.Add("@ROLENAME", createRoleDto.ROLENAME);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteRole(int[] roleid)
        {
            string query = "DELETE FROM ROLE WHERE ROLEID = @ROLEID";

            var parameters = new DynamicParameters();
            parameters.Add("@ROLEID", roleid);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultRoleDto>> GetAllRoles()
        {
            string query = "SELECT * FROM ROLE";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultRoleDto>(query);
                return result.ToList();
            }
        }

        public async Task<List<ResultRoleDto>> GetRoleById(int roleid)
        {
            string query = "SELECT * FROM ROLE WHERE ROLEID = @ROLEID";

            var parameters = new DynamicParameters();
            parameters.Add("@ROLEID", roleid);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultRoleDto>(query, parameters);
                return result.ToList();
            }
        }

        public async Task UpdateRole(int roleid, UpdateRoleDto updateRoleDto)
        {
            string query = "UPDATE ROLE SET ROLENAME = @ROLENAME WHERE ROLEID = @ROLEID";

            var parameters = new DynamicParameters();
            parameters.Add("@ROLENAME", updateRoleDto.ROLENAME);
            parameters.Add("@ROLEID", roleid);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
