using Api.Domain.Entities;
using AutoMapper;
using Data.Mapping;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}