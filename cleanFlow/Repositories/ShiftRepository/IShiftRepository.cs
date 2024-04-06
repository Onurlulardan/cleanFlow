using cleanFlow.Dtos.ShiftDtos;
namespace cleanFlow.Repositories.ShiftRepository
{
    public interface IShiftRepository
    {
        Task<List<ResultShiftDto>> GetAllShift();
        Task<List<ResultShiftDto>> GetShiftById(int shiftid);
        Task CreateShift(CreateShiftDto createShiftDto);
        Task UpdateShift(int shiftid, UpdateShiftDto updateShiftDto);
        Task DeleteShift(int[] shiftid);
    }
}
