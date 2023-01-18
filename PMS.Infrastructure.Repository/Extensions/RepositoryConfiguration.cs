using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMS.Core.Repository.User;
using PMS.Infrastructure.Repository.User;

namespace PMS.Infrastructure.Repository.Extensions
{
    public static class RepositoryConfiguration
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            #region User
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion
        }
    }
}
