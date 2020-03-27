using System.Threading.Tasks;
using Domain.DTOs;

namespace Domain.Interfaces.Services.Users
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto dto);
    }
}