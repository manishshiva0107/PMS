using PMS.Core.Entities.User;
using PMS.Core.Repository.User;
using PMS.Core.Services.User;
using System;
using System.Threading.Tasks;

namespace PMS.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDetails> Login(UserDetails user)
        {
            return await _userRepository.Login(user);
        }
    }
}
