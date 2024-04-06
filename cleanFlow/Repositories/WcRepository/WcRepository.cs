using cleanFlow.Dtos.WcDtos;
using cleanFlow.Model.DapperContext;
using Dapper;

namespace cleanFlow.Repositories.WcRepository
{
    public class WcRepository : IWcRepository
    {
        private readonly Context _context;
        public WcRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateWc(CreateWcDto createWcDto)
        {
            string query = "INSERT INTO WC (SECTION, WCTYPE, MAHALCODE, LOCATIONID) VALUES (@SECTION, @WCTYPE, @MAHALCODE, @LOCATIONID)";

            var parameters = new DynamicParameters();
            parameters.Add("@SECTION", createWcDto.SECTION);
            parameters.Add("@WCTYPE", createWcDto.WCTYPE);
            parameters.Add("@MAHALCODE", createWcDto.MAHALCODE);
            parameters.Add("@LOCATIONID", createWcDto.LOCATIONID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteWc(int wcid)
        {
            string query = "DELETE FROM WC WHERE WCID = @WCID";

            var parameters = new DynamicParameters();
            parameters.Add("@WCID", wcid);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWcDto>> GetAllWc()
        {
            string query = "SELECT A.*, B.LOCATIONNAME FROM WC A LEFT JOIN LOCATIONS B ON A.LOCATIONID = B.LOCATIONID";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultWcDto>(query);
                return result.ToList();
            }
        }

        public async Task<List<ResultWcDto>> GetWcById(int wcid)
        {
            string query = "SELECT A.*, B.LOCATIONNAME FROM WC A LEFT JOIN LOCATIONS B ON A.LOCATIONID = B.LOCATIONID WHERE WCID = @WCID";

            var parameters = new DynamicParameters();
            parameters.Add("@WCID", wcid);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultWcDto>(query, parameters);
                return result.ToList();
            }
        }

        public async Task UpdateWc(UpdateWcDto updateWcDto)
        {
            string query = "UPDATE WC SET SECTION = @SECTION, WCTYPE = @WCTYPE, MAHALCODE = @MAHALCODE, LOCATIONID = @LOCATIONID WHERE WCID = @WCID";

            var parameters = new DynamicParameters();
            parameters.Add("@SECTION", updateWcDto.SECTION);
            parameters.Add("@WCTYPE", updateWcDto.WCTYPE);
            parameters.Add("@MAHALCODE", updateWcDto.MAHALCODE);
            parameters.Add("@LOCATIONID", updateWcDto.LOCATIONID);
            parameters.Add("@WCID", updateWcDto.WCID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
