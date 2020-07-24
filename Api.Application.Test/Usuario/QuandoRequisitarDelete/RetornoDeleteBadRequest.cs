using System;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.Users;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarDelete
{
    public class RetornoUpdateBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar o Delete na UsersController e retornar um BadRequest")]
        public async Task E_Possivel_Invocar_a_UsersController_Delete_Retornando_BadRequest()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");
            
            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
        
    }
}
