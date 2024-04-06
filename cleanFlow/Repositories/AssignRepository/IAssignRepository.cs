using cleanFlow.Dtos.AssignDtos;

namespace cleanFlow.Repositories.AssignRepository
{
    public interface IAssignRepository
    {
        Task<List<ResultByPersonelDto>> GetAllAssignByPersonelId(int personelId);
        Task<List<ResultAssignDto>> GetAssignById(int assignId);
        Task CreateAssign(CreateAssignDto createAssignDto);
        Task UpdateAssign(UpdateAssignDto updateAssignDto);
        Task DeleteAssign(int[] assignId);
    }
}
