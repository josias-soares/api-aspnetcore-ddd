using System;
using System.Threading.Tasks;
using Domain.DTOs.User;
using Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Services.Test.Usuario
{
    public class QuandoForExecutadoGet: UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Executar o metodo <Get> e retornar um objeto valido.")]
        public async Task Executar_Metodo_Get_Recebe_Objeto_Valido()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(UserDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);
        }
        
        [Fact(DisplayName = "Executar o metodo <Get> e retornar um objeto NULL.")]
        public async Task Executar_Metodo_Get_Recebe_Objeto_Nulo()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);

            Assert.Null(result);
        }
    }
}
