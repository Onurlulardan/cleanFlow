using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cleanFlow.Dtos.WorkorderDtos;
using cleanFlow.Repositories.WorkOrderRepository;

namespace cleanFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private readonly IWorkOrderRepository _workOrderRepository;
        public WorkOrderController(IWorkOrderRepository workOrderRepository)
        {
            _workOrderRepository = workOrderRepository;
        }

        [HttpGet("assign/{assignId}")]
        public async Task<IActionResult> GetWorkOrdersByAssignId(int assignId)
        {
            try
            {
                var result = await _workOrderRepository.GetWorkOrdersByAssignId(assignId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkOrders()
        {
            try
            {
                var result = await _workOrderRepository.GetAllWorkOrders();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{workOrderId}")]
        public async Task<IActionResult> GetWorkOrderById(int workOrderId)
        {
            try
            {
                var result = await _workOrderRepository.GetWorkOrderById(workOrderId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("personel/{personelId}")]
        public async Task<IActionResult> GetWorkOrdersByPersonelId(int personelId)
        {
            try
            {
                var result = await _workOrderRepository.GetWorkOrdersByPersonelId(personelId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkOrder([FromForm] CreateWorkOrderDto createWorkOrderDto)
        {
            try
            {
                await _workOrderRepository.CreateWorkOrder(createWorkOrderDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{workOrderId}")]
        public async Task<IActionResult> UpdateWorkOrder(int workOrderId, [FromBody] UpdateWorkOrderDto updateWorkOrderDto)
        {
            try
            {
                await _workOrderRepository.UpdateWorkOrder(workOrderId, updateWorkOrderDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkOrder(int[] workOrderId)
        {
            try
            {
                await _workOrderRepository.DeleteWorkOrder(workOrderId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
    }
}
