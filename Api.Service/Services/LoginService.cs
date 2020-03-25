using System.Threading.Tasks;
using Api.Domain.Entities;
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

        public async Task<object> FindByLogin(UserEntity entity)
        {
            if (entity != null && !string.IsNullOrWhiteSpace(entity.Email))
            {
                return await _repository.FindBylogin(entity.Email);
            }

            return null;
        }
    }
}