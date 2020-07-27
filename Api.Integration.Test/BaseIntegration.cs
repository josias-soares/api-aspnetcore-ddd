using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application;
using AutoMapper;
using CrossCutting.Mappings;
using Data.Context;
using Domain.DTOs.Login;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext MyContext { get; set; } 
        public HttpClient Client { get; set; }
        public IMapper Mapper { get; set; }
        public string hostApi { get; set; }
        public HttpResponseMessage response { get; set; }

        public BaseIntegration()
        {
            hostApi = "http://localhost:5000/api";
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(builder);
            
            MyContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            MyContext.Database.Migrate();

            Mapper = new AutoMapperFixture().GetMapper();

            Client = server.CreateClient();
        }


        public async Task AdicionarToken()
        {
            var loginDto = new LoginRequestDto()
            {
                Email = "adm@email.com"
            };

            var resultLogin = await PostJsonAsync(loginDto, $"{hostApi}/login", Client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin);
            
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject.AcessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataClass, string url, HttpClient client)
        {
            return await client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(dataClass), Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            MyContext.Dispose();
            Client.Dispose();
        }
    }
    
    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}