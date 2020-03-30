using System.Threading.Tasks;
using Domain.DTOs;

namespace Domain.Interfaces.Services.Users
{
    public interface ILoginService
    {
        Task<LoginResponseDto> FindByLogin(LoginRequestDto requestDto);
    }
}