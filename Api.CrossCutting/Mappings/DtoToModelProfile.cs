using AutoMapper;
using Domain.DTOs;
using Domain.DTOs.User;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, ResponseBaseDto>().ReverseMap();
            CreateMap<UserModel, RequestBaseDto>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoCreateResult>().ReverseMap();
            
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdateResult>().ReverseMap();
            
            CreateMap<UserModel, UserDto>().ReverseMap();
        }
    }
}