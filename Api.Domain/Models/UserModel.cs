using System;

namespace Domain.Models
{
    public class UserModel
    {
        private Guid _id;
        private string _name;
        private string _email;
        private DateTime _createAt;
        private DateTime _updateAt;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public DateTime CreateAt
        {
            get => _createAt;
            set => _createAt = value;
        }

        public DateTime UpdateAt
        {
            get => _updateAt;
            set => _updateAt = value;
        }
    }
}