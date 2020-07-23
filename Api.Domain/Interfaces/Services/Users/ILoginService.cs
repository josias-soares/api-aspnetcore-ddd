using System.Threading.Tasks;
using Domain.DTOs;
using Domain.DTOs.Login;

namespace Domain.Interfaces.Services.Users
{
    public interface ILoginService
    {
        Task<LoginResponseDto> FindByLogin(LoginRequestDto requestDto);
    }
}