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
    public class RetornoUpdateOk
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar o Delete na UsersControllere retornar true")]
        public async Task E_Possivel_Invocar_a_UsersController_Delete_Retornando_True()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            
            _controller = new UsersController(serviceMock.Object);
       
            var result = await _controller.Delete(Guid.NewGuid());
            
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value;
            Assert.NotNull(resultValue);
            Assert.True((bool) resultValue);
        }
        
    }
}
