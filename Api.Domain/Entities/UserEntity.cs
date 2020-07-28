namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            
        }
        public string Name { get; set; }

        public string Email { get; set; }        
    }
}
