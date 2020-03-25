using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Domain.Interfaces.Services.Users
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserEntity entity);
    }
}