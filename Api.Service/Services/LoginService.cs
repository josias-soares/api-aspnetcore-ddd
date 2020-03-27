using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Interfaces.Services.Users;
using Domain.Repository;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(LoginDto dto)
        {
            if (dto != null && !string.IsNullOrWhiteSpace(dto.Email))
            {
                return await _repository.FindByLogin(dto.Email);
            }

            return null;
        }
    }
}