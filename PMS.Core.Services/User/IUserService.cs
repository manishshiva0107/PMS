using PMS.Core.Entities.User;
using System;
using System.Threading.Tasks;

namespace PMS.Core.Services.User
{
    public interface IUserService
    {
        public Task<UserDetails> Login(UserDetails user);
    }
}
