using cleanFlow.Dtos.AuditWorkOrderDtos;
using Dapper;
using cleanFlow.Model.DapperContext;

namespace cleanFlow.Repositories.AuditWorkOrderRepository
{
    public class AuditWorkOrderRepository : IAuditWorkOrderRepository
    {
        private readonly Context _context;
        public AuditWorkOrderRepository(Context context)
        {
            _context = context;
        }

        public Task CreateAuditWorkOrder(CreateAuditWorkOrderDtos createWorkOrderDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuditWorkOrder(int[] workOrderId)
        {
            throw new NotImplementedException();
        }

        public Task<(List<ResultAuditWorkOrderDto> Data, int Total)> GetAllAuditWorkOrders(int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultAuditWorkOrderDto>> GetAuditWorkOrderById(int workOrderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultAuditWorkOrderImagesDto>> GetAuditWorkOrdersByAssignId(int assignId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultAuditWorkOrderImagesDto>> GetAuditWorkOrdersByPersonelId(int personelId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultAuditWorkOrderDto>> SearchAuditWorkOrder(string search)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAuditWorkOrder(int workOrderId, UpdateAuditWorkOrderDto updateWorkOrderDto)
        {
            throw new NotImplementedException();
        }
    }
}
