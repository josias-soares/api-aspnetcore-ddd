using System;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.Users;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGet
{
    public class RetornoGetBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar um Get na UserController e retorna BadRequest")]
        public async Task E_Possivel_Invocar_a_UsersController_Get_Retornando_BadRequest()
        {
            var serviceMock = new Mock<IUserService>();
      
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(new UserDto
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow
            });
            
            _controller =  new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");
            
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
