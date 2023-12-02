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
            #region AutoMapper

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #endregion


            #region Services

            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPropertiesService, PropertiesService>();
            services.AddTransient<IPropertiesTypesService, PropertiesTypesServices>();
            services.AddTransient<ISalesTypeService, SalesTypesServices>();
            services.AddTransient<IImprovementsService, ImprovementsServices>();

            #endregion

        }
    }
}
