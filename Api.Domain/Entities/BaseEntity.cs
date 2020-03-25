
using System;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value;}
        }
        

        public DateTime? UpdateAt { get; set; }
    }
}
