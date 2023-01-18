using Microsoft.Extensions.DependencyInjection;
using PMS.Core.Services.User;
using PMS.Infrastructure.Services.User;

namespace PMS.Infrastructure.Services.Extensions
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            #region User
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
