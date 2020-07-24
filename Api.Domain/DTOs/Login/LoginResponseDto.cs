using System;

namespace Domain.DTOs.Login
{
    public class LoginResponseDto : ResponseBaseDto
    {
        public bool Authenticate {get; set;}
        public DateTime Created {get; set;}
        public DateTime Expiration {get; set;}
        public string AcessToken {get; set;}
        public string UserName {get; set;}
        public string Message {get; set;}

        public LoginResponseDto(bool authenticate, DateTime created, DateTime expiration, string acessToken, string userName, string message)
        {
            Authenticate = authenticate;
            Created = created;
            Expiration = expiration;
            AcessToken = acessToken;
            UserName = userName;
            Message = message;
        }

        public LoginResponseDto(bool authenticate, string message)
        {
            Authenticate = authenticate;
            Message = message;
        }
    }
}