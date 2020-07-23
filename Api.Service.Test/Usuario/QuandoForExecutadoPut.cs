using System;
using System.Threading.Tasks;
using Domain.DTOs.User;
using Domain.Interfaces.Services.Users;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace Api.Services.Test.Usuario
{
    public class QuandoForExecutadoPut: UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Executar o metodo <Put> e retornar um objeto valido.")]
        public async Task Executar_Metodo_Put_Recebe_Objeto_Valido()
        {
            // Criar Usuario
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(UserDtoCreate)).ReturnsAsync(UserDtoCreateResult);
            _service = _serviceMock.Object;

            var resultCreate = await _service.Post(UserDtoCreate);
            
            Assert.NotNull(resultCreate);
            Assert.Equal(NomeUsuario, resultCreate.Name);
            Assert.Equal(EmailUsuario, resultCreate.Email);
            
            // Alterar Usuario
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(UserDtoUpdate)).ReturnsAsync(UserDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(UserDtoUpdate);
            
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);
        }
    }
}