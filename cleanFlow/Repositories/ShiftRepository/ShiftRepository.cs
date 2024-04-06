using Dapper;
using cleanFlow.Model.DapperContext;
using cleanFlow.Dtos.ShiftDtos;

namespace cleanFlow.Repositories.ShiftRepository
{
    public class ShiftRepository: IShiftRepository
    {
        private readonly Context _context;
        public ShiftRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateShift(CreateShiftDto createShiftDto)
        {
            string query = "INSERT INTO SHIFT (SHIFTSTARTDATE, SHIFTENDDATE) VALUES (@SHIFTSTARTDATE, @SHIFTENDDATE)";

            var parameters = new DynamicParameters();
            parameters.Add("@SHIFTSTARTDATE", createShiftDto.SHIFTSTARTDATE);
            parameters.Add("@SHIFTENDDATE", createShiftDto.SHIFTENDDATE);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteShift(int[] shiftid)
        {
            string query = "DELETE FROM SHIFT WHERE SHIFTID = @SHIFTID";

            var parameters = new DynamicParameters();
            parameters.Add("@SHIFTID", shiftid);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultShiftDto>> GetAllShift()
        {
            string query = "SELECT * FROM SHIFT";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultShiftDto>(query);
                return result.ToList();
            }
        }

        public async Task<List<ResultShiftDto>> GetShiftById(int shiftid)
        {
            string query = "SELECT * FROM SHIFT WHERE SHIFTID = @SHIFTID";

            var parameters = new DynamicParameters();
            parameters.Add("@SHIFTID", shiftid);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultShiftDto>(query, parameters);
                return result.ToList();
            }
        }

        public async Task UpdateShift(int shiftid, UpdateShiftDto updateShiftDto)
        {
            string query = "UPDATE SHIFT SET SHIFTSTARTDATE = @SHIFTSTARTDATE, SHIFTENDDATE = @SHIFTENDDATE WHERE SHIFTID = @SHIFTID";

            var parameters = new DynamicParameters();
            parameters.Add("@SHIFTSTARTDATE", updateShiftDto.SHIFTSTARTDATE);
            parameters.Add("@SHIFTENDDATE", updateShiftDto.SHIFTENDDATE);
            parameters.Add("@SHIFTID", shiftid);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
