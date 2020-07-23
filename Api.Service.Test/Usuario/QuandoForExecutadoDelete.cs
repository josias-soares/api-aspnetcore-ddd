using System;
using System.Threading.Tasks;
using Domain.DTOs.User;
using Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Services.Test.Usuario
{
    public class QuandoForExecutadoDelete: UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Executar o metodo <Delete> com sucesso")]
        public async Task Executar_Metodo_Delete_Com_Sucesso()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(IdUsuario)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(IdUsuario);
            
            Assert.True(result);
        }
        
        [Fact(DisplayName = "Executar o metodo <Delete> com falha")]
        public async Task Executar_Metodo_Delete_Com_Falha()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            var result = await _service.Delete(Guid.NewGuid());

            Assert.False(result);
        }
    }
}