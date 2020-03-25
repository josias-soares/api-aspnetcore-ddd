using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Data.Context;
using Data.Repository;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataSet;
        
        public UserImplementation(MyContext context, DbSet<UserEntity> dataSet) : base(context)
        {
            _dataSet = dataSet;
        }

        public async Task<UserEntity> FindBylogin(string email)
        {
            return await _dataSet.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }
        
    }
}