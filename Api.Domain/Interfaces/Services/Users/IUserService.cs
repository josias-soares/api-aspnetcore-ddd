using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs.User;

namespace Domain.Interfaces.Services.Users
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);

        Task<IEnumerable<UserDto>> GetAll();

        Task<UserDtoCreateResult> Post(UserDtoCreate dto);

        Task<UserDtoUpdateResult> Put(UserDtoUpdate dto);

        Task<bool> Delete(Guid id);
    }
}