using System;

namespace Domain.DTOs.User
{
    public class UserDtoCreateResult : ResponseBaseDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreateAt { get; set; }
        
        public DateTime UpdateAt { get; set; }
    }
}