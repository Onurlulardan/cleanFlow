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

        public async Task<List<ResultWorkOrderDto>> GetAllWorkOrders()
        {
            string query = "SELECT A.WORKORDERID, B.NAME, B.SURNAME, E.LOCATIONNAME, D.MAHALCODE, A.CREATED_AT, F.SHIFTSTARTDATE, F.SHIFTENDDATE FROM WORKORDER A LEFT JOIN PERSONELS B ON A.PERSONELID = B.PERSONELID LEFT JOIN ASSIGN C ON A.ASSIGNID = C.ASSIGNID LEFT JOIN WC D ON C.WCID = D.WCID LEFT JOIN LOCATIONS E ON D.LOCATIONID = E.LOCATIONID LEFT JOIN SHIFT F ON A.SHIFTID = F.SHIFTID";

            using (var connection = _context.CreateConnection())
            {
                var reuslt = await connection.QueryAsync<ResultWorkOrderDto>(query);
                return reuslt.ToList();
            }
        }

        public async Task<List<ResultWorkOrderImagesDto>> GetWorkOrderById(int workOrderId)
        {
            string query = "SELECT A.WORKORDERID, A.ASSIGNID, A.PERSONELID, B.*  FROM WORKORDER A LEFT JOIN WORKORDERIMG B ON A.WORKORDERID = B.WORKORDERID WHERE A.WORKORDERID = @WORKORDERID";

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

        public async Task<Byte[]> ConvertToByteArray(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public async Task UpdateWorkOrder(int workOrderId, UpdateWorkOrderDto updateWorkOrderDto)
        {
            string query = "UPDATE WORKORDER SET ASSIGNID = @ASSIGNID, SHIFTID = @SHIFTID, PERSONELID = @PERSONELID, LAVABO_PHOTO = @LAVABO_PHOTO, PISUAR_PHOTO = @PISUAR_PHOTO, KLOZET_PHOTO = @KLOZET_PHOTO, TEZGAH_PHOTO = @TEZGAH_PHOTO, SABUNLUK_PHOTO = @SABUNLUK_PHOTO, KABIN_PHOTO = @KABIN_PHOTO, AYNA_PHOTO = @AYNA_PHOTO, COP_PHOTO = @COP_PHOTO, TUVALET_KAGIDI_PHOTO = @TUVALET_KAGIDI_PHOTO, HAVLU_MAKINESI_PHOTO = @HAVLU_MAKINESI_PHOTO WHERE WORKORDERID = @WORKORDERID";

            var parameters = new DynamicParameters();
            parameters.Add("@WORKORDERID", workOrderId);
            parameters.Add("@ASSIGNID", updateWorkOrderDto.ASSIGNID);
            parameters.Add("@SHIFTID", updateWorkOrderDto.SHIFTID);
            parameters.Add("@PERSONELID", updateWorkOrderDto.PERSONELID);
            parameters.Add("@LAVABO_PHOTO", updateWorkOrderDto.LAVABO_PHOTO != null ? await ConvertToByteArray(updateWorkOrderDto.LAVABO_PHOTO) : null);
            parameters.Add("@PISUAR_PHOTO", updateWorkOrderDto.PISUAR_PHOTO != null ? await ConvertToByteArray(updateWorkOrderDto.PISUAR_PHOTO) : null);
            parameters.Add("@KLOZET_PHOTO", updateWorkOrderDto.KLOZET_PHOTO != null ? await ConvertToByteArray(updateWorkOrderDto.KLOZET_PHOTO) : null);
            parameters.Add("@TEZGAH_PHOTO", updateWorkOrderDto.TEZGAH_PHOTO != null ? await ConvertToByteArray(updateWorkOrderDto.TEZGAH_PHOTO) : null);
            parameters.Add("@SABUNLUK_PHOTO", updateWorkOrderDto.SABUNLUK_PHOTO != null ? await ConvertToByteArray(updateWorkOrderDto.SABUNLUK_PHOTO) : null);
            parameters.Add("@KABIN_PHOTO", updateWorkOrderDto.KABIN_PHOTO != null ? await ConvertToByteArray(updateWorkOrderDto.KABIN_PHOTO) : null);
            parameters.Add("@AYNA_PHOTO", updateWorkOrderDto.AYNA_PHOTO != null ? await ConvertToByteArray(updateWorkOrderDto.AYNA_PHOTO) : null);
            parameters.Add("@COP_PHOTO", updateWorkOrderDto.COP_PHOTO != null ? await ConvertToByteArray(updateWorkOrderDto.COP_PHOTO) : null);
            parameters.Add("@TUVALET_KAGIDI_PHOTO", updateWorkOrderDto.TUVALET_KAGIDI_PHOTO != null ? await ConvertToByteArray(updateWorkOrderDto.TUVALET_KAGIDI_PHOTO) : null);
            parameters.Add("@HAVLU_MAKINESI_PHOTO", updateWorkOrderDto.HAVLU_MAKINESI_PHOTO != null ? await ConvertToByteArray(updateWorkOrderDto.HAVLU_MAKINESI_PHOTO) : null);

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
            parameters.Add("@LAVABO_PHOTO", createWorkOrderDto.LAVABO_PHOTO != null ? await ConvertToByteArray(createWorkOrderDto.LAVABO_PHOTO) : null);
            parameters.Add("@PISUAR_PHOTO", createWorkOrderDto.PISUAR_PHOTO != null ? await ConvertToByteArray(createWorkOrderDto.PISUAR_PHOTO) : null);
            parameters.Add("@KLOZET_PHOTO", createWorkOrderDto.KLOZET_PHOTO != null ? await ConvertToByteArray(createWorkOrderDto.KLOZET_PHOTO) : null);
            parameters.Add("@TEZGAH_PHOTO", createWorkOrderDto.TEZGAH_PHOTO != null ? await ConvertToByteArray(createWorkOrderDto.TEZGAH_PHOTO) : null);
            parameters.Add("@SABUNLUK_PHOTO", createWorkOrderDto.SABUNLUK_PHOTO != null ? await ConvertToByteArray(createWorkOrderDto.SABUNLUK_PHOTO) : null);
            parameters.Add("@KABIN_PHOTO", createWorkOrderDto.KABIN_PHOTO != null ? await ConvertToByteArray(createWorkOrderDto.KABIN_PHOTO) : null);
            parameters.Add("@AYNA_PHOTO", createWorkOrderDto.AYNA_PHOTO != null ? await ConvertToByteArray(createWorkOrderDto.AYNA_PHOTO) : null);
            parameters.Add("@COP_PHOTO", createWorkOrderDto.COP_PHOTO != null ? await ConvertToByteArray(createWorkOrderDto.COP_PHOTO) : null);
            parameters.Add("@TUVALET_KAGIDI_PHOTO", createWorkOrderDto.TUVALET_KAGIDI_PHOTO != null ? await ConvertToByteArray(createWorkOrderDto.TUVALET_KAGIDI_PHOTO) : null);
            parameters.Add("@HAVLU_MAKINESI_PHOTO", createWorkOrderDto.HAVLU_MAKINESI_PHOTO != null ? await ConvertToByteArray(createWorkOrderDto.HAVLU_MAKINESI_PHOTO) : null);

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
    }
}
