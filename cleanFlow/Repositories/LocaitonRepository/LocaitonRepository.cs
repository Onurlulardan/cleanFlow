using Dapper;
using cleanFlow.Dtos.LocaitonDtos;
using cleanFlow.Model.DapperContext;

namespace cleanFlow.Repositories.LocaitonRepository
{
    public class LocaitonRepository: ILocaitonRepository
    {
        private readonly Context _context;
        public LocaitonRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateLocation(CreateLocaitonDto location)
        {
            string query = "INSERT INTO LOCATIONS (LOCATIONNAME) VALUES (@LOCATIONNAME)";

            var parameters = new DynamicParameters();
            parameters.Add("@LOCATIONNAME", location.LOCATIONNAME);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteLocation(int[] locationId)
        {
            string query = "DELETE FROM LOCATIONS WHERE LOCATIONID IN @LOCATIONID";

            var parameters = new DynamicParameters();
            parameters.Add("@LOCATIONID", locationId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultLocationDto>> GetAllLocation()
        {
            string query = "SELECT * FROM LOCATIONS";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultLocationDto>(query);
                return result.ToList();
            }
        }

        public async Task<List<ResultLocationDto>> GetLocationById(int locationId)
        {
            string query = "SELECT * FROM LOCATIONS WHERE LOCATIONID = @LOCATIONID";

            var parameters = new DynamicParameters();
            parameters.Add("@LOCATIONID", locationId);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultLocationDto>(query, parameters);
                return result.ToList();
            }
        }

        public async Task UpdateLocation(int locationId, UpdateLocationDto location)
        {
            string query = "UPDATE LOCATIONS SET LOCATIONNAME = @LOCATIONNAME WHERE LOCATIONID = @LOCATIONID";

            var parameters = new DynamicParameters();
            parameters.Add("@LOCATIONID", locationId);
            parameters.Add("@LOCATIONNAME", location.LOCATIONNAME);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
