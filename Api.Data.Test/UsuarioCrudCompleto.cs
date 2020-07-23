using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Data.Context;
using Data.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuario")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                var email = "Nome Test";
                var name = "email@email.com";
                
                UserEntity entity = new UserEntity
                {
                    Name = name,
                    Email = email
                };

                var registroCriado = await _repository.InsertAsync(entity);
                
                Assert.NotNull(registroCriado);
                
                Assert.False(registroCriado.Id == Guid.Empty);
                Assert.Equal(name, registroCriado.Name);
                Assert.Equal(email, registroCriado.Email);
            }
        }
        
        
        
        
    }
}