using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs.User;
using Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Services.Test.Usuario
{
    public class QuandoForExecutadoGetAll: UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Executar o metodo  <GetAll>  e retornar uma lista com objetos.")]
        public async Task Executar_Metodo_GetAll_Retorna_Lista_Com_Objetos()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUserDtos);
            _service = _serviceMock.Object;

            var results = await _service.GetAll();
            
            Assert.NotNull(results);
            Assert.True(results.Count() == listaUserDtos.Count());
        }
        
        [Fact(DisplayName = "Executar o metodo  <GetAll>  e retornar uma lista vazia.")]
        public async Task Executar_Metodo_GetAll_Retorna_Lista_Vazia()
        {
            var listResults = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listResults.AsEnumerable);
            _service = _serviceMock.Object;

            var results = await _service.GetAll();

            Assert.Empty(results);
            Assert.True(!results.Any());
        }
    }
}