using Dapper;
using cleanFlow.Dtos.AuditDtos;
using cleanFlow.Model.DapperContext;

namespace cleanFlow.Repositories.AuditRepository
{
    public class AuditRepository : IAuditRepository
    {
        private readonly Context _context;
        public AuditRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateAudit(CreateAuditDto createAuditDto)
        {
            string query = "INSERT INTO AUDIT (CHIEFFID) VALUES (@CHIEFFID)";

            var parameters = new DynamicParameters();
            parameters.Add("@CHIEFFID", createAuditDto.CHIEFFID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteAudit(int[] auditId)
        {
            string query = "DELETE FROM AUDIT WHERE AUDITID IN @AUDITID";

            var parameters = new DynamicParameters();
            parameters.Add("@AUDITID", auditId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePersonelFromAudit(int personelId)
        {
            string query = "DELETE FROM AUDITPERSONELS WHERE PERSONELID = @PERSONELID";

            var parameters = new DynamicParameters();

            parameters.Add("@PERSONELID", personelId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultAuditDto>> GetAllAudit()
        {
            string query = "SELECT A.*, B.NAME, B.SURNAME, C.ROLENAME, B.PHONENUMBER FROM AUDIT A LEFT JOIN PERSONELS B ON A.CHIEFFID = B.PERSONELID LEFT JOIN ROLE C ON B.ROLEID = C.ROLEID";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultAuditDto>(query);
                return result.ToList();
            }
        }

        public async Task<List<ResultAuditDto>> GetAuditById(int auditId)
        {
            string query = "SELECT A.*, B.NAME, B.SURNAME, C.ROLENAME, B.PHONENUMBER FROM AUDIT A LEFT JOIN PERSONELS B ON A.CHIEFFID = B.PERSONELID LEFT JOIN ROLE C ON B.ROLEID = C.ROLEID WHERE AUDITID = @AUDITID";

            var parameters = new DynamicParameters();
            parameters.Add("@AUDITID", auditId);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultAuditDto>(query, parameters);
                return result.ToList();
            }
        }

        public async Task AddPersonelToAudit(UpdateAuditDto updateAuditDto)
        {
            var auditId = updateAuditDto.CHIEFFID;
            var personelIds = updateAuditDto.PERSONELID;

            var newPersonelIds = new List<int>();

            foreach(var personelId in personelIds)
            {
                string existQuery = "SELECT COUNT(1) FROM AUDITPERSONELS WHERE AUDITID = @AUDITID AND PERSONELID = @PERSONELID";

                var parameters = new DynamicParameters();
                parameters.Add("@AUDITID", auditId);
                parameters.Add("@PERSONELID", personelId);

                using (var connection = _context.CreateConnection())
                {
                    var exist = await connection.ExecuteScalarAsync<bool>(existQuery, parameters);

                    if (!exist)
                    {
                        newPersonelIds.Add(personelId);
                    }
                }
            }

            if (newPersonelIds.Count > 0)
            {
                string insertQuery = "INSERT INTO AUDITPERSONELS (AUDITID, PERSONELID) VALUES (@AUDITID, @PERSONELID)";

                foreach (var personelId in newPersonelIds)
                {
                    var insertParameters = new DynamicParameters();
                    insertParameters.Add("@AUDITID", auditId);
                    insertParameters.Add("@PERSONELID", personelId);

                    using (var connection = _context.CreateConnection())
                    {
                        await connection.ExecuteAsync(insertQuery, insertParameters);
                    }
                }
            }


        }
    }
}
