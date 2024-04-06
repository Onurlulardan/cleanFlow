using cleanFlow.Dtos.WcDtos;

namespace cleanFlow.Repositories.WcRepository
{
    public interface IWcRepository
    {
        Task<List<ResultWcDto>> GetAllWc();
        Task<List<ResultWcDto>> GetWcById(int wcid);
        Task CreateWc(CreateWcDto createWcDto);
        Task UpdateWc(int wcid, UpdateWcDto updateWcDto);
        Task DeleteWc(int[] wcid);
    }
}
