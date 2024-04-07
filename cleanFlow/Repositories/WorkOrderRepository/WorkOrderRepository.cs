using Dapper;
using cleanFlow.Dtos.WorkorderDtos;
using cleanFlow.Model.DapperContext;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace cleanFlow.Repositories.WorkOrderRepository
{
    public class WorkOrderRepository : IWorkOrderRepository
    {
        private readonly Context _context;
        public WorkOrderRepository(Context context)
        {
            _context = context;
        }
        public async Task DeleteWorkOrder(int[] workOrderId)
        {
            string query = "DELETE FROM WORKORDER WHERE WORKORDERID IN @WORKORDERID";

            var parameters = new DynamicParameters();
            parameters.Add("@WORKORDERID", workOrderId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<(List<ResultWorkOrderDto> Data, int Total)> GetAllWorkOrders(int page, int limit)
        {
            int offset = page * limit;

            string query = @$"SELECT A.WORKORDERID, B.NAME, B.SURNAME, E.LOCATIONNAME, D.MAHALCODE, A.CREATED_AT, F.SHIFTSTARTDATE, F.SHIFTENDDATE 
                              FROM WORKORDER A 
                              LEFT JOIN PERSONELS B ON A.PERSONELID = B.PERSONELID 
                              LEFT JOIN ASSIGN C ON A.ASSIGNID = C.ASSIGNID 
                              LEFT JOIN WC D ON C.WCID = D.WCID 
                              LEFT JOIN LOCATIONS E ON D.LOCATIONID = E.LOCATIONID 
                              LEFT JOIN SHIFT F ON A.SHIFTID = F.SHIFTID
                              ORDER BY A.CREATED_AT DESC
                              LIMIT @Limit OFFSET @Offset";

            string countQuery = "SELECT COUNT(*) FROM WORKORDER";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultWorkOrderDto>(query, new { Offset = offset, Limit = limit });
                var total = await connection.ExecuteScalarAsync<int>(countQuery);
                return (result.ToList(), total);
            }
        }

        public async Task<List<ResultWorkOrderImagesDto>> GetWorkOrderById(int workOrderId)
        {
            string query = "SELECT * FROM WORKORDERIMG WHERE WORKORDERID = @WORKORDERID";

            var parameters = new DynamicParameters();
            parameters.Add("@WORKORDERID", workOrderId);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync(query, parameters);

                var resultList = new List<ResultWorkOrderImagesDto>();

                foreach (var item in result)
                {
                    var dto = new ResultWorkOrderImagesDto
                    {
                        WORKORDERID = item.WORKORDERID,
                        ASSINGID = item.ASSINGID,
                        PERSONELID = item.PERSONELID,
                        SHIFTID = item.SHIFTID,
                        LAVABO_PHOTO = item.LAVABO_PHOTO != null ? Convert.ToBase64String(item.LAVABO_PHOTO) : null,
                        PISUAR_PHOTO = item.PISUAR_PHOTO != null ? Convert.ToBase64String(item.PISUAR_PHOTO) : null,
                        KLOZET_PHOTO = item.KLOZET_PHOTO != null ? Convert.ToBase64String(item.KLOZET_PHOTO) : null,
                        TEZGAH_PHOTO = item.TEZGAH_PHOTO != null ? Convert.ToBase64String(item.TEZGAH_PHOTO) : null,
                        SABUNLUK_PHOTO = item.SABUNLUK_PHOTO != null ? Convert.ToBase64String(item.SABUNLUK_PHOTO) : null,
                        KABIN_PHOTO = item.KABIN_PHOTO != null ? Convert.ToBase64String(item.KABIN_PHOTO) : null,
                        AYNA_PHOTO = item.AYNA_PHOTO != null ? Convert.ToBase64String(item.AYNA_PHOTO) : null,
                        COP_PHOTO = item.COP_PHOTO != null ? Convert.ToBase64String(item.COP_PHOTO) : null,
                        TUVALET_KAGIDI_PHOTO = item.TUVALET_KAGIDI_PHOTO != null ? Convert.ToBase64String(item.TUVALET_KAGIDI_PHOTO) : null,
                        HAVLU_MAKINESI_PHOTO = item.HAVLU_MAKINESI_PHOTO != null ? Convert.ToBase64String(item.HAVLU_MAKINESI_PHOTO) : null,
                    };

                    resultList.Add(dto);
                }

                return resultList;
            }
        }

        public async Task<List<ResultWorkOrderImagesDto>> GetWorkOrdersByPersonelId(int personelId)
        {
            string query = "SELECT A.WORKORDERID, A.ASSIGNID, A.PERSONELID, B.*  FROM WORKORDER A LEFT JOIN WORKORDERIMG B ON A.WORKORDERID = B.WORKORDERID WHERE A.PERSONELID = @PERSONELID";

            var parameters = new DynamicParameters();
            parameters.Add("@PERSONELID", personelId);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync(query, parameters);

                var resultList = new List<ResultWorkOrderImagesDto>();

                foreach (var item in result)
                {
                    var dto = new ResultWorkOrderImagesDto
                    {
                        WORKORDERID = item.WORKORDERID,
                        ASSINGID = item.ASSINGID,
                        PERSONELID = item.PERSONELID,
                        SHIFTID = item.SHIFTID,
                        LAVABO_PHOTO = item.LAVABO_PHOTO != null ? Convert.ToBase64String(item.LAVABO_PHOTO) : null,
                        PISUAR_PHOTO = item.PISUAR_PHOTO != null ? Convert.ToBase64String(item.PISUAR_PHOTO) : null,
                        KLOZET_PHOTO = item.KLOZET_PHOTO != null ? Convert.ToBase64String(item.KLOZET_PHOTO) : null,
                        TEZGAH_PHOTO = item.TEZGAH_PHOTO != null ? Convert.ToBase64String(item.TEZGAH_PHOTO) : null,
                        SABUNLUK_PHOTO = item.SABUNLUK_PHOTO != null ? Convert.ToBase64String(item.SABUNLUK_PHOTO) : null,
                        KABIN_PHOTO = item.KABIN_PHOTO != null ? Convert.ToBase64String(item.KABIN_PHOTO) : null,
                        AYNA_PHOTO = item.AYNA_PHOTO != null ? Convert.ToBase64String(item.AYNA_PHOTO) : null,
                        COP_PHOTO = item.COP_PHOTO != null ? Convert.ToBase64String(item.COP_PHOTO) : null,
                        TUVALET_KAGIDI_PHOTO = item.TUVALET_KAGIDI_PHOTO != null ? Convert.ToBase64String(item.TUVALET_KAGIDI_PHOTO) : null,
                        HAVLU_MAKINESI_PHOTO = item.HAVLU_MAKINESI_PHOTO != null ? Convert.ToBase64String(item.HAVLU_MAKINESI_PHOTO) : null,
                    };

                    resultList.Add(dto);
                }

                return resultList;
            }
        }

        public byte[] ConvertBase64ToBytes(string base64String)
        {
            return string.IsNullOrEmpty(base64String) ? null : Convert.FromBase64String(base64String);
        }

        private void AddParameterIfNotNull(DynamicParameters parameters, List<string> setClauses, string fieldName, string base64Value)
        {
            if (!string.IsNullOrWhiteSpace(base64Value))
            {
                setClauses.Add($"{fieldName} = @{fieldName}");
                parameters.Add($"@{fieldName}", ConvertBase64ToBytes(base64Value));
            }
        }

        public async Task UpdateWorkOrder(int workOrderId, UpdateWorkOrderDto updateWorkOrderDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@WORKORDERID", workOrderId);

            var setClauses = new List<string>();

            var photos = new Dictionary<string, string>
            {
                { "LAVABO_PHOTO", updateWorkOrderDto.LAVABO_PHOTO },
                { "PISUAR_PHOTO", updateWorkOrderDto.PISUAR_PHOTO },
                { "KLOZET_PHOTO", updateWorkOrderDto.KLOZET_PHOTO },
                { "TEZGAH_PHOTO", updateWorkOrderDto.TEZGAH_PHOTO },
                { "SABUNLUK_PHOTO", updateWorkOrderDto.SABUNLUK_PHOTO },
                { "KABIN_PHOTO", updateWorkOrderDto.KABIN_PHOTO },
                { "AYNA_PHOTO", updateWorkOrderDto.AYNA_PHOTO },
                { "COP_PHOTO", updateWorkOrderDto.COP_PHOTO },
                { "TUVALET_KAGIDI_PHOTO", updateWorkOrderDto.TUVALET_KAGIDI_PHOTO },
                { "HAVLU_MAKINESI_PHOTO", updateWorkOrderDto.HAVLU_MAKINESI_PHOTO }
            };

            foreach (var photo in photos)
            {
                AddParameterIfNotNull(parameters, setClauses, photo.Key, photo.Value);
            }

            if (!setClauses.Any())
            {
                throw new InvalidOperationException("Güncellenecek veri yok!");
            }

            string query = $"UPDATE WORKORDERIMG SET {string.Join(", ", setClauses)} WHERE WORKORDERID = @WORKORDERID";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task CreateWorkOrder(CreateWorkOrderDto createWorkOrderDto)
        {

            string createWorkorderQuery = "INSERT INTO WORKORDER (ASSIGNID, SHIFTID, PERSONELID) VALUES (@ASSIGNID, @SHIFTID, @PERSONELID); SELECT LAST_INSERT_ID() AS LastID;";

            var createWorkorderParameters = new DynamicParameters();
            createWorkorderParameters.Add("@ASSIGNID", createWorkOrderDto.ASSIGNID);
            createWorkorderParameters.Add("@SHIFTID", createWorkOrderDto.SHIFTID);
            createWorkorderParameters.Add("@PERSONELID", createWorkOrderDto.PERSONELID);
            int workOrderId;

            using (var connection = _context.CreateConnection())
            {
                workOrderId = await connection.QuerySingleAsync<int>(createWorkorderQuery, createWorkorderParameters);
            }

            string imgQuery = "INSERT INTO WORKORDERIMG (WORKORDERID, LAVABO_PHOTO, PISUAR_PHOTO, KLOZET_PHOTO, TEZGAH_PHOTO, SABUNLUK_PHOTO, KABIN_PHOTO, AYNA_PHOTO, COP_PHOTO, TUVALET_KAGIDI_PHOTO, HAVLU_MAKINESI_PHOTO) VALUES (@WORKORDERID, @LAVABO_PHOTO, @PISUAR_PHOTO, @KLOZET_PHOTO, @TEZGAH_PHOTO, @SABUNLUK_PHOTO, @KABIN_PHOTO, @AYNA_PHOTO, @COP_PHOTO, @TUVALET_KAGIDI_PHOTO, @HAVLU_MAKINESI_PHOTO)";

            var parameters = new DynamicParameters();
            parameters.Add("@WORKORDERID", workOrderId);
            parameters.Add("@LAVABO_PHOTO", ConvertBase64ToBytes(createWorkOrderDto.LAVABO_PHOTO));
            parameters.Add("@PISUAR_PHOTO", ConvertBase64ToBytes(createWorkOrderDto.PISUAR_PHOTO));
            parameters.Add("@KLOZET_PHOTO", ConvertBase64ToBytes(createWorkOrderDto.KLOZET_PHOTO));
            parameters.Add("@TEZGAH_PHOTO", ConvertBase64ToBytes(createWorkOrderDto.TEZGAH_PHOTO));
            parameters.Add("@SABUNLUK_PHOTO", ConvertBase64ToBytes(createWorkOrderDto.SABUNLUK_PHOTO));
            parameters.Add("@KABIN_PHOTO", ConvertBase64ToBytes(createWorkOrderDto.KABIN_PHOTO));
            parameters.Add("@AYNA_PHOTO", ConvertBase64ToBytes(createWorkOrderDto.AYNA_PHOTO));
            parameters.Add("@COP_PHOTO", ConvertBase64ToBytes(createWorkOrderDto.COP_PHOTO));
            parameters.Add("@TUVALET_KAGIDI_PHOTO", ConvertBase64ToBytes(createWorkOrderDto.TUVALET_KAGIDI_PHOTO));
            parameters.Add("@HAVLU_MAKINESI_PHOTO", ConvertBase64ToBytes(createWorkOrderDto.HAVLU_MAKINESI_PHOTO));

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(imgQuery, parameters);
            }
        }

        public async Task<List<ResultWorkOrderImagesDto>> GetWorkOrdersByAssignId(int assignId)
        {
            string query = "SELECT A.WORKORDERID, A.ASSIGNID, A.PERSONELID, A.SHIFTID, B.LAVABO_PHOTO, B.PISUAR_PHOTO, B.KLOZET_PHOTO, B.TEZGAH_PHOTO, B.SABUNLUK_PHOTO, B.KABIN_PHOTO, B.AYNA_PHOTO, B.COP_PHOTO,B.HAVLU_MAKINESI_PHOTO, B.TUVALET_KAGIDI_PHOTO, A.CREATED_AT FROM WORKORDER A LEFT JOIN WORKORDERIMG B ON A.WORKORDERID = B.WORKORDERID WHERE A.ASSIGNID = @ASSIGNID AND DATE(A.CREATED_AT) = CURDATE()";


            var parameters = new DynamicParameters();
            parameters.Add("@ASSIGNID", assignId);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync(query, parameters);

                var resultList = new List<ResultWorkOrderImagesDto>();

                foreach (var item in result)
                {
                    var dto = new ResultWorkOrderImagesDto
                    {
                        WORKORDERID = item.WORKORDERID,
                        ASSINGID = item.ASSINGID,
                        PERSONELID = item.PERSONELID,
                        SHIFTID = item.SHIFTID,
                        LAVABO_PHOTO = item.LAVABO_PHOTO != null ? Convert.ToBase64String(item.LAVABO_PHOTO) : null,
                        PISUAR_PHOTO = item.PISUAR_PHOTO != null ? Convert.ToBase64String(item.PISUAR_PHOTO) : null,
                        KLOZET_PHOTO = item.KLOZET_PHOTO != null ? Convert.ToBase64String(item.KLOZET_PHOTO) : null,
                        TEZGAH_PHOTO = item.TEZGAH_PHOTO != null ? Convert.ToBase64String(item.TEZGAH_PHOTO) : null,
                        SABUNLUK_PHOTO = item.SABUNLUK_PHOTO != null ? Convert.ToBase64String(item.SABUNLUK_PHOTO) : null,
                        KABIN_PHOTO = item.KABIN_PHOTO != null ? Convert.ToBase64String(item.KABIN_PHOTO) : null,
                        AYNA_PHOTO = item.AYNA_PHOTO != null ? Convert.ToBase64String(item.AYNA_PHOTO) : null,
                        COP_PHOTO = item.COP_PHOTO != null ? Convert.ToBase64String(item.COP_PHOTO) : null,
                        TUVALET_KAGIDI_PHOTO = item.TUVALET_KAGIDI_PHOTO != null ? Convert.ToBase64String(item.TUVALET_KAGIDI_PHOTO) : null,
                        HAVLU_MAKINESI_PHOTO = item.HAVLU_MAKINESI_PHOTO != null ? Convert.ToBase64String(item.HAVLU_MAKINESI_PHOTO) : null,
                    };

                    resultList.Add(dto);
                }

                return resultList;
            }
        }

        public async Task<List<ResultWorkOrderDto>> SearchWorkOrder(string search)
        {
            string query = @$"SELECT 
                            A.WORKORDERID, 
                            D.SECTION, 
                            D.MAHALCODE, 
                            D.WCTYPE,
                            E.LOCATIONNAME,
                            B.NAME,
                            B.SURNAME,
                            B.PHONENUMBER,
                            B.USERNAME,
                            B.AGE
                            FROM WORKORDER A 
                            LEFT JOIN PERSONELS B ON A.PERSONELID = B.PERSONELID 
                            LEFT JOIN ASSIGN C ON A.ASSIGNID = C.ASSIGNID 
                            LEFT JOIN WC D ON C.WCID = D.WCID 
                            LEFT JOIN LOCATIONS E ON D.LOCATIONID = E.LOCATIONID 
                            LEFT JOIN SHIFT F ON A.SHIFTID = F.SHIFTID
                            WHERE 
                            A.WORKORDERID LIKE @Search
                            OR D.SECTION LIKE @Search 
                            OR D.MAHALCODE LIKE @Search
                            OR D.WCTYPE LIKE @Search
                            OR E.LOCATIONNAME LIKE @Search
                            OR B.NAME LIKE @Search
                            OR B.SURNAME LIKE @Search
                            OR B.PHONENUMBER LIKE @Search
                            OR B.USERNAME LIKE @Search
                            OR B.AGE LIKE @Search
                            ORDER BY A.CREATED_AT DESC";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultWorkOrderDto>(query, new { Search = $"%{search}%" });
                return result.ToList();
            }
        }
    }
}
