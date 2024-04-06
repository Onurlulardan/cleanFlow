using Dapper;
using cleanFlow.Dtos.AssignDtos;
using cleanFlow.Model.DapperContext;

namespace cleanFlow.Repositories.AssignRepository
{
    public class AssignRepository : IAssignRepository
    {

        private readonly Context _context;
        public AssignRepository(Context context)
        {
               _context = context;
        }
        public async Task CreateAssign(CreateAssignDto createAssignDto)
        {
            string query = "INSERT INTO ASSIGN (PERSONELID, WCID) VALUES (@PERSONELID, @WCID)";
            string updateWcStatus = "UPDATE WC SET ASSIGNSTATUS = 1 WHERE WCID = @WCID";

            var parameters = new DynamicParameters();
            parameters.Add("@PERSONELID", createAssignDto.PERSONELID);
            parameters.Add("@WCID", createAssignDto.WCID);

            var wcParameters = new DynamicParameters();
            wcParameters.Add("@WCID", createAssignDto.WCID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                await connection.ExecuteAsync(updateWcStatus, wcParameters);
            }
        }

        public async Task DeleteAssign(int[] assignId)
        {
            string query = "DELETE FROM ASSIGN WHERE ASSIGNID = @ASSIGNID";

            var parameters = new DynamicParameters();
            parameters.Add("@ASSIGNID", assignId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultByPersonelDto>> GetAllAssignByPersonelId(int personelId)
        {
            string query = "SELECT A.*, B.NAME, B.SURNAME, C.WCTYPE, C.MAHALCODE, C.LOCATIONID, WL.LOCATIONNAME, C.SECTION FROM ASSIGN A LEFT JOIN PERSONELS B ON A.PERSONELID = B.PERSONELID LEFT JOIN WC C ON A.WCID = C.WCID LEFT JOIN LOCATIONS WL ON C.LOCATIONID = WL.LOCATIONID WHERE A.PERSONELID = @PERSONELID";

            var parameters = new DynamicParameters();
            parameters.Add("@PERSONELID", personelId);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultByPersonelDto>(query, parameters);
                return result.ToList();
            }
        }

        public async Task<List<ResultAssignDto>> GetAssignById(int assignId)
        {
            string query = "SELECT * FROM ASSIGN WHERE ASSIGNID = @ASSIGNID";

            var parameters = new DynamicParameters();
            parameters.Add("@ASSIGNID", assignId);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultAssignDto>(query, parameters);
                return result.ToList();
            }
        }

        public async Task UpdateAssign(UpdateAssignDto updateAssignDto)
        {
            string query = "UPDATE ASSIGN SET PERSONELID = @PERSONELID,WCID = @WCID  WHERE ASSIGNID = @ASSIGNID";

            var parameters = new DynamicParameters();
            parameters.Add("@PERSONELID", updateAssignDto.PERSONELID);
            parameters.Add("@WCID", updateAssignDto.WCID);
            parameters.Add("@ASSIGNID", updateAssignDto.ASSIGNID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
