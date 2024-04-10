using cleanFlow.Dtos.AuditWorkOrderDtos;

namespace cleanFlow.Repositories.AuditWorkOrderRepository
{
    public interface IAuditWorkOrderRepository
    {
        Task<(List<ResultAuditWorkOrderDto> Data, int Total)> GetAllAuditWorkOrders(int page, int limit);
        Task<List<ResultAuditWorkOrderDto>> GetAuditWorkOrderById(int workOrderId);
        Task UpdateAuditWorkOrder(int workOrderId, UpdateAuditWorkOrderDto updateWorkOrderDto);
        Task DeleteAuditWorkOrder(int[] workOrderId);
        Task<List<ResultAuditWorkOrderImagesDto>> GetAuditWorkOrdersByPersonelId(int personelId);
        Task CreateAuditWorkOrder(CreateAuditWorkOrderDtos createWorkOrderDto);
        Task<List<ResultAuditWorkOrderImagesDto>> GetAuditWorkOrdersByAssignId(int assignId);
        Task<List<ResultAuditWorkOrderDto>> SearchAuditWorkOrder(string search);
    }
}
