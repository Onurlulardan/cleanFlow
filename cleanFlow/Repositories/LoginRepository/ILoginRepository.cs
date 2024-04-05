using cleanFlow.Dtos.LoginDtos;

namespace cleanFlow.Repositories.LoginRepository
{
    public interface ILoginRepository
    {
        Task<LoginDto> Login(LoginDto loginDto);
    }
}
