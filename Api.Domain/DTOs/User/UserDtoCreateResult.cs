using System;

namespace Domain.DTOs.User
{
    public class UserDtoCreateResult : ResponseBaseDto
    {
        public UserDtoCreateResult()
        {
            
        }

        public UserDtoCreateResult(Guid id, string name, string email, DateTime at)
        {
            Id = id;
            Name = name;
            Email = email;
            CreateAt = at;
        }

        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreateAt { get; set; }
        
        //public DateTime UpdateAt { get; set; }
    }
}
