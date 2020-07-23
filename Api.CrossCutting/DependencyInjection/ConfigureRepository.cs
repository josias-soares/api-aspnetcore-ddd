using System;
using Data.Context;
using Data.Implementations;
using Data.Repository;
using Domain.Interfaces;
using Domain.Interfaces.Services.Users;
using Domain.Repository;
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
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            var database = Environment.GetEnvironmentVariable("DATABASE") ?? "";
            var dbConnection = Environment.GetEnvironmentVariable("DB_CONNECTION") ?? "";
            if (database.ToLower().Equals("MYSQL".ToLower()))
            {
                serviceCollection.AddDbContext<MyContext>(options => options.UseMySql(dbConnection));
            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(options => options.UseMySql("Server=localhost;Port=3306;Database=dbApi;Uid=root;Pwd=jma7995"));
            }
        }
    }
}