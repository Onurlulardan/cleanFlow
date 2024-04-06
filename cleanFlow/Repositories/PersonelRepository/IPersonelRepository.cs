using cleanFlow.Dtos.PersonelDtos;

namespace cleanFlow.Repositories.PersonelRepository
{
    public interface IPersonelRepository
    {
        Task<List<ResultPersonelDto>> getAllPersonels();
        Task CreatePersonel(CreatePersonelDto createPersonelDto);

        void UpdatePersonel(int personelId, UpdatePersonelDto updatePersonelDto);

        void DeletePersonel(int[] personelId);

        Task<List<ResultPersonelDto>> getPersonelById(int personelId);
    }
}
