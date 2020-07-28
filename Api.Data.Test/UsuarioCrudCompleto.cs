using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;


namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuario")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            await using (var context = _serviceProvider.GetService<MyContext>())
            {
                var repository = new UserImplementation(context);

                var entity = new UserEntity
                {
                    Name = Faker.Internet.Email(),
                    Email = Faker.Name.FullName()
                };
                
                // Insert
                var registroCriado = await repository.InsertAsync(entity);
                
                Assert.NotNull(registroCriado);
                
                Assert.False(registroCriado.Id == Guid.Empty);
                Assert.Equal(entity.Name, registroCriado.Name);
                Assert.Equal(entity.Email, registroCriado.Email);

                //Update
                entity.Name = Faker.Name.First();
                var registroAtualizado = await repository.UpdateAsync(entity);
                Assert.NotNull(registroAtualizado);
                Assert.Equal(entity.Email, registroAtualizado.Email);
                Assert.Equal(entity.Name, registroAtualizado.Name);
                
                // Exist?
                var registroExiste = await repository.ExistAsync(registroAtualizado.Id);
                Assert.True(registroExiste);
                
                // Select
                var registroSelecionado = await repository.SelectAsync(registroAtualizado.Id);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(registroSelecionado.Name, registroAtualizado.Name);
                Assert.Equal(registroSelecionado.Email, registroAtualizado.Email);
                
                // GetAll
                var todosRegistros = await repository.SelectAsync();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Any());
                
                // Login
                var usuarioPadrao = await repository.FindByLogin("adm@email.com");
                Assert.NotNull(usuarioPadrao);
                Assert.Equal("Administrador", usuarioPadrao.Name);
                Assert.Equal("adm@email.com", usuarioPadrao.Email);
            }
        }
        
    }
}
