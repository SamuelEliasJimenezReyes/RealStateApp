using Microsoft.Extensions.DependencyInjection;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.Services;
using System.Reflection;
using MediatR;
using RealStateApp.Core.Application.Dtos.Account;
using Microsoft.AspNetCore.Http;

namespace RealStateApp.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion
          
            #region MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());
            #endregion

            #region Services

            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPropertiesService, PropertiesService>();
            services.AddTransient<IPropertiesTypesService, PropertiesTypesServices>();
            services.AddTransient<ISalesTypeService, SalesTypesServices>();
            services.AddTransient<IImprovementsService, ImprovementsServices>();
            services.AddTransient<IImagesPropertiesService, ImagesPropertiesService>();
            services.AddTransient<IPropertiesImprovementsService, PropertiesImprovementsService>();
            services.AddTransient<IAgentImagesService, AgentImagesService>();
            services.AddTransient<AuthenticationResponse>();
           
            #endregion

        }
    }
}
