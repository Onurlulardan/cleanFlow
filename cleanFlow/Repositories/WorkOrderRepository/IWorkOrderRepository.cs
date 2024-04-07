using cleanFlow.Dtos.WorkorderDtos;

namespace cleanFlow.Repositories.WorkOrderRepository
{
    public interface IWorkOrderRepository
    {
        Task<(List<ResultWorkOrderDto> Data, int Total)> GetAllWorkOrders(int page, int limit);
        Task<List<ResultWorkOrderImagesDto>> GetWorkOrderById(int workOrderId);
        Task UpdateWorkOrder(int workOrderId, UpdateWorkOrderDto updateWorkOrderDto);
        Task DeleteWorkOrder(int[] workOrderId);
        Task<List<ResultWorkOrderImagesDto>> GetWorkOrdersByPersonelId(int personelId);
        Task CreateWorkOrder(CreateWorkOrderDto createWorkOrderDto);
        Task<List<ResultWorkOrderImagesDto>> GetWorkOrdersByAssignId(int assignId);
        Task<List<ResultWorkOrderDto>> SearchWorkOrder(string search);
    }
}
