namespace Domain.DTOs
{
    public class LoginResponseDto : ResponseBaseDto
    {
        public bool Authenticate {get; set;}
        public string Created {get; set;}
        public string Expiration {get; set;}
        public string AcessToken {get; set;}
        public string UserName {get; set;}
        public string Message {get; set;}

        public LoginResponseDto(bool authenticate, string created, string expiration, string acessToken, string userName, string message)
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