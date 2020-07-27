using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.Users;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGetAll
{
    public class RetornoGetAllBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar um GetAll na UserController e retorna BadRequest")]
        public async Task E_Possivel_Invocar_a_UsersController_GetAll_Retornando_BadRequest()
        {
            var serviceMock = new Mock<IUserService>();
       
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(new List<UserDto>
            {
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = Name.FullName(),
                    Email = Internet.Email(),
                    CreateAt = DateTime.UtcNow
                },
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = Name.FullName(),
                    Email = Internet.Email(),
                    CreateAt = DateTime.UtcNow
                }
            });
            
            _controller =  new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");
            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}