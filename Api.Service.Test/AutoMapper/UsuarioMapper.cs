using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DTOs.User;
using Domain.Entities;
using Domain.Models;
using Faker;
using Xunit;

namespace Api.Services.Test.AutoMapper
{
    public class UsuarioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possivel mapear Models para Entity")]
        public void E_Possivel_Mapear_Models_P_Entity()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            
            // Model => Entity
            var modelToEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.Name, model.Name);
            Assert.Equal(modelToEntity.Email, model.Email);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);
        }
        
        //Dto => Model
        [Fact(DisplayName = "É possivel mapear Models para UserDto")]
        public void E_Possivel_Mapear_Models_P_UserDto()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
        
            var modelToUserDto = Mapper.Map<UserDto>(model);
            Assert.Equal(modelToUserDto.Id, model.Id);
            Assert.Equal(modelToUserDto.Name, model.Name);
            Assert.Equal(modelToUserDto.Email, model.Email);
            Assert.Equal(modelToUserDto.CreateAt, model.CreateAt);
            Assert.Equal(modelToUserDto.UpdateAt, model.UpdateAt);
        }

        [Fact(DisplayName = "É possivel mapear Models para UserDtoCreate")]
        public void E_Possivel_Mapear_Models_P_UserDtoCreate()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
        
            var modelToUserDtoCreate = Mapper.Map<UserDtoCreate>(model);
            Assert.Equal(modelToUserDtoCreate.Name, model.Name);
            Assert.Equal(modelToUserDtoCreate.Email, model.Email);
        }
        
        [Fact(DisplayName = "É possivel mapear Models para UserDtoCreateResult")]
        public void E_Possivel_Mapear_Models_P_UserDtoCreateResult()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
        
            var modelToUserDtoCreateResult = Mapper.Map<UserDtoCreateResult>(model);
            Assert.Equal(modelToUserDtoCreateResult.Id, model.Id);
            Assert.Equal(modelToUserDtoCreateResult.Name, model.Name);
            Assert.Equal(modelToUserDtoCreateResult.Email, model.Email);
            Assert.Equal(modelToUserDtoCreateResult.CreateAt, model.CreateAt);
            //Assert.Equal(modelToUserDtoCreateResult.UpdateAt, model.UpdateAt);
        }
        
        [Fact(DisplayName = "É possivel mapear Models para UserDtoUpdate")]
        public void E_Possivel_Mapear_Models_P_UserDtoUpdate()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
        
            var modelToUserDtoUpdate = Mapper.Map<UserDtoUpdate>(model);
            Assert.Equal(modelToUserDtoUpdate.Id, model.Id);
            Assert.Equal(modelToUserDtoUpdate.Name, model.Name);
            Assert.Equal(modelToUserDtoUpdate.Email, model.Email);
        }
        
        [Fact(DisplayName = "É possivel mapear Models para UserDtoUpdateResult")]
        public void E_Possivel_Mapear_Models_P_UserDtoUpdateResult()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
        
                   
            var modelToUserDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(model);
            Assert.Equal(modelToUserDtoUpdateResult.Id, model.Id);
            Assert.Equal(modelToUserDtoUpdateResult.Name, model.Name);
            Assert.Equal(modelToUserDtoUpdateResult.Email, model.Email);
            Assert.Equal(modelToUserDtoUpdateResult.CreateAt, model.CreateAt);
            Assert.Equal(modelToUserDtoUpdateResult.UpdateAt, model.UpdateAt);
        }
        
        // Entity => Dto
        [Fact(DisplayName = "É possivel mapear Entity para DTOs")]
        public void E_Possivel_Mapear_Entity_DTOs()
        {
            var entity = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            
            // DTO => Entity
            var entityToDto = Mapper.Map<UserDto>(entity);
            Assert.Equal(entityToDto.Id, entity.Id);
            Assert.Equal(entityToDto.Name, entity.Name);
            Assert.Equal(entityToDto.Email, entity.Email);
            Assert.Equal(entityToDto.CreateAt, entity.CreateAt);
            Assert.Equal(entityToDto.UpdateAt, entity.UpdateAt);
        }
        
        [Fact(DisplayName = "É possivel mapear List<Entity> para List<DTOs>")]
        public void E_Possivel_Mapear_Lista_Entity_P_Lista_DTOs()
        {
            var listEntity = new List<UserEntity>();

            for (int i = 0; i < 10; i++)
            {
                var entity = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Name.FullName(),
                    Email = Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                
                listEntity.Add(entity);
            }
            
            var listDto = Mapper.Map<List<UserDto>>(listEntity);
            Assert.True(listDto.Count() == listEntity.Count());

            for (int i = 0; i < listEntity.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listEntity[i].Id);
                Assert.Equal(listDto[i].Name, listEntity[i].Name);
                Assert.Equal(listDto[i].Email, listEntity[i].Email);
                Assert.Equal(listDto[i].CreateAt, listEntity[i].CreateAt);
                Assert.Equal(listDto[i].UpdateAt, listEntity[i].UpdateAt);
            }
        }
        
        [Fact(DisplayName = "É possivel mapear Entity para DtoCreate")]
        public void E_Possivel_Mapear_Entity_P_DtoCreate()
        {
            var entity = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            
            var entityToCreate = Mapper.Map<UserDtoCreate>(entity);
            Assert.Equal(entityToCreate.Name, entity.Name);
            Assert.Equal(entityToCreate.Email, entity.Email);
        }

        [Fact(DisplayName = "É possivel mapear Entity para DtoCreateResult")]
        public void E_Possivel_Mapear_Entity_P_DtoCreateResult()
        {
            var entity = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            
            var entityToCreateResult = Mapper.Map<UserDtoCreateResult>(entity);
            Assert.Equal(entityToCreateResult.Id, entity.Id);
            Assert.Equal(entityToCreateResult.Name, entity.Name);
            Assert.Equal(entityToCreateResult.Email, entity.Email);
            Assert.Equal(entityToCreateResult.CreateAt, entity.CreateAt);
            //Assert.Equal(entityToCreateResult.UpdateAt, entity.UpdateAt);
        }
        
        [Fact(DisplayName = "É possivel mapear Entity para DtoUpdate")]
        public void E_Possivel_Mapear_Entity_P_DtoUpdate()
        {
            var entity = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            
            var entityToUpdate = Mapper.Map<UserDtoUpdate>(entity);
            Assert.Equal(entityToUpdate.Id, entity.Id);
            Assert.Equal(entityToUpdate.Name, entity.Name);
            Assert.Equal(entityToUpdate.Email, entity.Email);
        }
        
        [Fact(DisplayName = "É possivel mapear Entity para DtoUpdateResult")]
        public void E_Possivel_Mapear_Entity_P_DtoUpdateResult()
        {
            var entity = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            
            var entityToUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
            Assert.Equal(entityToUpdateResult.Id, entity.Id);
            Assert.Equal(entityToUpdateResult.Name, entity.Name);
            Assert.Equal(entityToUpdateResult.Email, entity.Email);
            Assert.Equal(entityToUpdateResult.CreateAt, entity.CreateAt);
            Assert.Equal(entityToUpdateResult.UpdateAt, entity.UpdateAt);
        }
    }
}