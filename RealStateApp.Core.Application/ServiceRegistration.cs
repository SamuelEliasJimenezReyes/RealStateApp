using Microsoft.Extensions.DependencyInjection;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.Services;
using System.Reflection;

namespace RealStateApp.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region 

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #endregion
            #region Services
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
