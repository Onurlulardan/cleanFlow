using cleanFlow.Dtos.WorkorderDtos;

namespace cleanFlow.Repositories.WorkOrderRepository
{
    public interface IWorkOrderRepository
    {
        Task<List<ResultWorkOrderDto>> GetAllWorkOrders();
        Task<List<ResultWorkOrderImagesDto>> GetWorkOrderById(int workOrderId);
        Task UpdateWorkOrder(int workOrderId, UpdateWorkOrderDto updateWorkOrderDto);
        Task DeleteWorkOrder(int[] workOrderId);
        Task<List<ResultWorkOrderImagesDto>> GetWorkOrdersByPersonelId(int personelId);
        Task CreateWorkOrder(CreateWorkOrderDto createWorkOrderDto);
        Task<List<ResultWorkOrderImagesDto>> GetWorkOrdersByAssignId(int assignId);
    }
}
