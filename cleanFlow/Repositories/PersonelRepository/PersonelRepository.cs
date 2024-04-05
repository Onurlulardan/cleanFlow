using Dapper;
using cleanFlow.Dtos.PersonelDtos;
using cleanFlow.Model.DapperContext;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace cleanFlow.Repositories.PersonelRepository
{
    public class PersonelRepository : IPersonelRepository
    {
        private readonly Context _context;

        public PersonelRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> IsUsernameExist(string username)
        {
            string query = "SELECT COUNT(1) FROM PERSONELS WHERE USERNAME = @USERNAME";

            using (var connection = _context.CreateConnection())
            {
                var exist = await connection.ExecuteScalarAsync<bool>(query, new {USERNAME = username});
                return exist;
            }
        }
        public async Task CreatePersonel(CreatePersonelDto createPersonelDto)
        {
            bool userExist = await IsUsernameExist(createPersonelDto.USERNAME);
            if (userExist)
            {
                throw new Exception("Bu kullanıcı adı kullanılmakta.");
            }

            string query = "INSERT INTO PERSONELS(NAME, SURNAME, SEX, PASSWORD, PHONENUMBER, USERNAME, AGE, ROLEID) VALUES(@NAME, @SURNAME, @SEX, @PASSWORD, @PHONENUMBER, @USERNAME, @AGE, @ROLEID)";

            var parameters = new DynamicParameters();
            parameters.Add("@NAME", createPersonelDto.NAME);
            parameters.Add("@SURNAME", createPersonelDto.SURNAME);
            parameters.Add("@SEX", createPersonelDto.SURNAME);
            parameters.Add("@PASSWORD", createPersonelDto.PASSWORD);
            parameters.Add("@PHONENUMBER", createPersonelDto.PHONENUMBER);
            parameters.Add("@USERNAME", createPersonelDto.USERNAME);
            parameters.Add("@AGE", createPersonelDto.AGE);
            parameters.Add("@ROLEID", createPersonelDto.ROLEID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<List<ResultPersonelDto>> getAllPersonels()
        {
            string query = "SELECT A.*, B.ROLENAME FROM PERSONELS A LEFT JOIN ROLE B ON A.ROLEID = B.ROLEID";

            using (var conneciton = _context.CreateConnection())
            {
                var result = await conneciton.QueryAsync<ResultPersonelDto>(query);
                return result.ToList();
            }
        }

        public async Task<List<ResultPersonelDto>> getPersonelById(int personelId)
        {
            string query = "SELECT A.*, B.ROLENAME FROM PERSONELS A LEFT JOIN ROLE B ON A.ROLEID = B.ROLEID WHERE A.PERSONELID = @PERSONELID";

            var parameters = new DynamicParameters();
            parameters.Add("@PERSONELID", personelId);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultPersonelDto>(query, parameters);
                return result.ToList();
            }
        }

        public async void UpdatePersonel(UpdatePersonelDto updatePersonelDto)
        {
            string query = "UPDATE PERSONELS SET NAME = @NAME, SURNAME = @SURNAME, SEX = @SEX, PASSWORD = @PASSWORD, USERNAME = @USERNAME, AGE = @AGE, ROLEID = @ROLEID WHERE PERSONELID = @PERSONELID";

            var parameters = new DynamicParameters();
            parameters.Add("@NAME", updatePersonelDto.NAME);
            parameters.Add("@SURNAME", updatePersonelDto.SURNAME);
            parameters.Add("@SEX", updatePersonelDto.SEX);
            parameters.Add("@PASSWORD", updatePersonelDto.PASSWORD);
            parameters.Add("@USERNAME", updatePersonelDto.USERNAME);
            parameters.Add("@AGE", updatePersonelDto.AGE);
            parameters.Add("@ROLEID", updatePersonelDto.ROLEID);
            parameters.Add("@PERSONELID", updatePersonelDto.PERSONELID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async void DeletePersonel(int[] personelId)
        {
            string query = "DELETE FROM PERSONELS WHERE PERSONELID IN @PERSONELID";

            var parameters = new DynamicParameters();
            parameters.Add("@PERSONELID", personelId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

    }
}
