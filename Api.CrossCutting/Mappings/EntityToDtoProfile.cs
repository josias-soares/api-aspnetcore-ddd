using AutoMapper;
using Domain.DTOs;
using Domain.DTOs.User;
using Domain.Entities;

namespace CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ResponseBaseDto, UserEntity>().ReverseMap();
            CreateMap<RequestBaseDto, UserEntity>().ReverseMap();
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreate, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdate, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();

        }
    }
}