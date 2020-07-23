using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using AutoMapper;
using Domain.DTOs.User;
using Domain.Interfaces;
using Domain.Interfaces.Services.Users;
using Domain.Models;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity =  await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity =  await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate dto)
        {
            var model = _mapper.Map<UserModel>(dto);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);
            
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate dto)
        {
            var model = _mapper.Map<UserModel>(dto);
            var entity = _mapper.Map<UserEntity>(model);
            var result =await _repository.UpdateAsync(entity);
            
            return _mapper.Map<UserDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}