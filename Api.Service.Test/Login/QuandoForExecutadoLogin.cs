using System;
using System.Threading.Tasks;
using Domain.DTOs.Login;
using Domain.Interfaces.Services.Users;
using Faker;
using Moq;
using Xunit;

namespace Api.Services.Test.Login
{
    public class QuandoForExecutadoLogin
    {
        private ILoginService _serviceLogin;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "E Possivel Executar Metod FindByLogin")]
        public async Task E_Possivel_Executar_Metodo_FindByLogin()
        {
            var email = Internet.Email();
            LoginResponseDto objRetorno = new LoginResponseDto(
                true,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(8),
                Guid.NewGuid().ToString(),
                Name.FullName(),
                "Login efetuado com sucesso."
            );

            var loginDto = new LoginRequestDto
            {
                Email = email
            };
            
            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objRetorno);
            _serviceLogin = _serviceMock.Object;
            
            var result = await _serviceLogin.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}
