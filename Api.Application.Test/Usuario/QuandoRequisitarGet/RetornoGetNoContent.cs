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
    public class RetornoGetNoContent
    
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar um Get na UserController e retorna NoContent")]
        public async Task E_Possivel_Invocar_a_UsersController_Get_Retornando_NoContent()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync((UserDto) null);
            
            _controller =  new UsersController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NoContentResult);
        }
    }
}