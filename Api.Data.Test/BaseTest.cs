using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
        }
    }

    public class DbTest : IDisposable
    {
        private string _dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", String.Empty)}";
        public ServiceProvider ServiceProvider { get; set; }

        public DbTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o => o.UseMySql(
                $"Persist Security Info=True;Server=localhost;Port=3306;Database={_dataBaseName};Uid=root;Pwd=jma7995"), 
                ServiceLifetime.Transient);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}