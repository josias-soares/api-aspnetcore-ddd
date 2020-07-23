using System;
using System.Threading.Tasks;
using Domain.DTOs.User;
using Domain.Interfaces.Services.Users;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace Api.Services.Test.Usuario
{
    public class QuandoForExecutadoPost: UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Executar o metodo <Post> e retornar um objeto valido.")]
        public async Task Executar_Metodo_Post_Recebe_Objeto_Valido()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(UserDtoCreate)).ReturnsAsync(UserDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(UserDtoCreate);
            
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);
        }
    }
}