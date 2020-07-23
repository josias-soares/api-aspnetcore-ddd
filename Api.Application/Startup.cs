using System;
using AutoMapper;
using CrossCutting.DependencyInjection;
using CrossCutting.Mappings;
using Data.Context;
using Domain.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);
            // Config DI AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            IMapper mapper = config.CreateMapper();
            // Injeção dependencia
            services.AddSingleton(mapper);
//            JWT
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
 //              vem do appSettings este "TokenConfigurations"
                Configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(
                authOptions =>
                {
                    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer",
                    new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .Build());
            });
            
//            JWT

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo {
                        Title = "Sigap API", 
                        Version = "v1", 
                        Contact = new OpenApiContact{Name= "Josias Soares", Url = new Uri("https://github.com/josias-soares")}
                    });
                c.EnableAnnotations();
                
                // Adicionar botao de jwt no swagger
                OpenApiSecurityScheme openApiSecurityScheme = new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Entre com o token JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Reference = new OpenApiReference 
                    { 
                        Type = ReferenceType.SecurityScheme, 
                        Id = "Bearer" 
                    }
                };
                
                c.AddSecurityDefinition("Bearer", openApiSecurityScheme);
                
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        openApiSecurityScheme,
                        new string[] {}
                    }
                });
                
//                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//                {
//                    In = ParameterLocation.Header,
//                    Description = "Entre com o token JWT",
//                    Name = "Authorization",
//                    Type = SecuritySchemeType.ApiKey
//                });
//                c.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {
//                    {
//                        new OpenApiSecurityScheme
//                        {
//                            Reference = new OpenApiReference 
//                            { 
//                                Type = ReferenceType.SecurityScheme, 
//                                Id = "Bearer" 
//                            }
//                        },
//                        new string[] {}
//
//                    }
//                });
            });

            services.AddMvc(options => { options.EnableEndpointRouting = false; });
            services
                .AddControllers()
                .AddNewtonsoftJson();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sigap API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(
                endpoints => { endpoints.MapControllers(); }
            );
            
            app.UseMvc();

            if (Environment.GetEnvironmentVariable("MIGRATION").ToLower().Equals("APLICAR".ToLower()))
            {
                using (var service = app
                    .ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    using (var context = service.ServiceProvider.GetService<MyContext>())
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
