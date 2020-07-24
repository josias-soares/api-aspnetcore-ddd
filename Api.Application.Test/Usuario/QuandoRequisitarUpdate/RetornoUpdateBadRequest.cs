using System;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.Users;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarUpdate
{
    public class RetornoUpdateBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar o Update na UsersController e retornar um BadRequest")]
        public async Task E_Possivel_Invocar_a_UsersController_Update_Retornando_BadRequest()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Name.FullName();
            var email = Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                });
            
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo Obrigatório");
            
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<Object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoUpdate = new UserDtoUpdate
            {
                Name = name,
                Email = email,
            };

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
        
    }
}
