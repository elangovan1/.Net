using Microsoft.Extensions.DependencyInjection;
using PMS.DataEFCore.DBContext;
using PMS.DataEFCore.Handler;
using PMS.DataEFCore.Repositories;
using PMS.Domain.Handler;
using PMS.Domain.Repositories;

namespace PMS.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, DatabaseContext>() 
                    .AddScoped<IPropertyRepository, PropertyTypeRepository>()
                    .AddScoped<IPropertyHandler, PropertyTypeHandler>();

            return services;
        }
    }
}
