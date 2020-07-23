using System;
using System.Collections.Generic;
using Domain.DTOs.User;
using Faker;

namespace Api.Services.Test.Usuario
{
    public class UsuarioTestes
    {
        public static string NomeUsuario { get; set; }
        public static string EmailUsuario { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string EmailUsuarioAlterado { get; set; }
        public static Guid IdUsuario { get; set; }

        public List<UserDto> listaUserDtos = new List<UserDto>();
        public UserDto UserDto;
        public UserDtoCreate UserDtoCreate;
        public UserDtoUpdate UserDtoUpdate;
        public UserDtoCreateResult UserDtoCreateResult;
        public UserDtoUpdateResult UserDtoUpdateResult;

        public UsuarioTestes()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Name.FullName();
            EmailUsuario = Internet.Email();
            NomeUsuarioAlterado = Name.FullName();
            EmailUsuarioAlterado = Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = Name.FullName(),
                    Email = Internet.Email()
                };
                
                listaUserDtos.Add(dto);
            }

            UserDto = new UserDto()
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            UserDtoCreate = new UserDtoCreate
            {
                Name = NomeUsuario,
                Email = EmailUsuario
            };
            
            UserDtoCreateResult = new UserDtoCreateResult
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario,
                CreateAt = DateTime.UtcNow
            };
            
            UserDtoUpdate = new UserDtoUpdate
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado
            };
            
            UserDtoUpdateResult = new UserDtoUpdateResult
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado
            };
        }
    }
}