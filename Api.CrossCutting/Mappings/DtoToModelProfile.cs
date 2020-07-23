using Api.Domain.Entities;
using AutoMapper;
using Domain.DTOs.User;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoCreateResult>().ReverseMap();
            
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdateResult>().ReverseMap();
            
            CreateMap<UserModel, UserDto>().ReverseMap();
        }
    }
}