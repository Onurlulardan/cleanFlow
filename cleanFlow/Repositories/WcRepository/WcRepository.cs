using cleanFlow.Dtos.WcDtos;
using cleanFlow.Model.DapperContext;

namespace cleanFlow.Repositories.WcRepository
{
    public class WcRepository : IWcRepository
    {
        private readonly Context _context;
        public WcRepository(Context context)
        {
            _context = context;
        }
        public Task<CreateWcDto> CreateWc(CreateWcDto createWcDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWc(int wcid)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultWcDto>> GetAllWc()
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultWcDto>> GetWcById(int wcid)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateWcDto> UpdateWc(UpdateWcDto updateWcDto)
        {
            throw new NotImplementedException();
        }
    }
}
