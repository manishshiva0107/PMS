using PMS.Core.Entities.User;
using System;
using System.Threading.Tasks;

namespace PMS.Core.Repository.User
{
    public interface IUserRepository
    {
        public Task<UserDetails> Login(UserDetails user);

    }
}
