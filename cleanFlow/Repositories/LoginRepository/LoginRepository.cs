using cleanFlow.Dtos.LoginDtos;
using Dapper;
using cleanFlow.Model.DapperContext;

namespace cleanFlow.Repositories.LoginRepository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly Context _context;

        public LoginRepository(Context context)
        {
            _context = context; 
        }
        public async Task<LoginDto> Login(LoginDto loginDto)
        {
            string query = "SELECT * FROM PERSONELS WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<string>(query, new { loginDto.USERNAME, loginDto.PASSWORD });
                if (result != null)
                {
                    return new LoginDto
                    {
                        USERNAME = loginDto.USERNAME
                    };
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
