using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealState.Infraestructure.Persistence.Context;
using RealState.Infraestructure.Persistence.Repositories;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealState.Infraestructure.Persistence
{
    public static class ServiceRegistation
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts 
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<RealStateContext>(options => options.UseInMemoryDatabase("AppConnectionString"));
            }
            else
            {
                services.AddDbContext<RealStateContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppConnectionString"),
                m => m.MigrationsAssembly(typeof(RealStateContext).Assembly.FullName)));
            }
            #endregion

            #region Repository
                services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion 
        }


    }
}
