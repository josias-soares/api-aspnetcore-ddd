using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.DTOs.Login;
using Domain.Entities;
using Domain.Interfaces.Services.Users;
using Domain.Repository;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private IConfiguration _configuration;

        public LoginService(IUserRepository repository, SigningConfigurations signingConfigurations, IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto> FindByLogin(LoginRequestDto requestDto)
        {
            var response = new LoginResponseDto(false,  "Falha ao autenticar");
            if (requestDto != null && !string.IsNullOrWhiteSpace(requestDto.Email))
            {
                UserEntity entity = await _repository.FindByLogin(requestDto.Email);

                if (entity == null)
                {
                    return response;
                }
                
                var identity = new ClaimsIdentity(
                    new GenericIdentity(entity.Email),
                    new [] 
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, entity.Email), 
                    }
                    );
                
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(Convert.ToDouble(Environment.GetEnvironmentVariable("Seconds")));
                
                var handler = new JwtSecurityTokenHandler();

                string token =  CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObject(createDate, expirationDate, token, requestDto);
            }

            return response;
        }

        private LoginResponseDto SuccessObject(in DateTime createDate, in DateTime expirationDate, string token, LoginRequestDto user)
        {
            return new LoginResponseDto (
                true,
                createDate, //ToString("yyyy-MM-dd HH:mm:ss"), 
                expirationDate, //.ToString("yyyy-MM-dd HH:mm:ss"), 
                token, 
                user.Email,
                "Login efetuado com sucesso."
            );
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate,
            JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);

            return token;
        }
    }
}