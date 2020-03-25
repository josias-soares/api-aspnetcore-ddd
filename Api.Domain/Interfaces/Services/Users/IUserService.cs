using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Domain.Interfaces.Services.Users
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);

        Task<IEnumerable<UserEntity>> GetAll();

        Task<UserEntity> Post(UserEntity entity);

        Task<UserEntity> Put(UserEntity entity);

        Task<bool> Delete(Guid id);
    }
}