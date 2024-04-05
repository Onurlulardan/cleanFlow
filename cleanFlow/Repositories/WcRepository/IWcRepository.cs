using cleanFlow.Dtos.WcDtos;

namespace cleanFlow.Repositories.WcRepository
{
    public interface IWcRepository
    {
        Task<List<ResultWcDto>> GetAllWc();
        Task<List<ResultWcDto>> GetWcById(int wcid);
        Task<CreateWcDto> CreateWc(CreateWcDto createWcDto);
        Task<UpdateWcDto> UpdateWc(UpdateWcDto updateWcDto);
        Task DeleteWc(int wcid);
    }
}
