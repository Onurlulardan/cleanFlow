using cleanFlow.Dtos.LocaitonDtos;

namespace cleanFlow.Repositories.LocaitonRepository
{
    public interface ILocaitonRepository
    {
        Task<List<ResultLocationDto>> GetAllLocation();

        Task<List<ResultLocationDto>> GetLocationById(int locationId);

        Task CreateLocation(CreateLocaitonDto location);

        Task UpdateLocation(int locationId, UpdateLocationDto location);

        Task DeleteLocation(int[] locationId);
    }
}
