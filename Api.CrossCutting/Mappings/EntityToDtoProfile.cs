using Api.Domain.Entities;
using AutoMapper;
using Domain.DTOs.User;

namespace CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreate, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdate, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();

        }
    }
}