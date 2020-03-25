using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Domain.Interfaces.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            
            serviceCollection.AddDbContext<MyContext>(options => options.UseMySql("Server=localhost;Port=3306;Database=dbApi;Uid=root;Pwd=jma7995"));
        }
    }
}