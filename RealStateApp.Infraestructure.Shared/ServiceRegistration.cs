using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Domain.Settings;
using RealStateApp.Infraestructure.Shared.Services;

namespace RealStateApp.Infraestructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedLayer(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
