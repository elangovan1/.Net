﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMS.DataEFCore.DBContext;

namespace PMS.API.Configurations
{
    public static class ConnectionString
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,  IConfiguration configuration)
        {            
            services.AddDbContext<DatabaseContext>(opts => opts.UseSqlServer(configuration["ConnectionString:PMSDB"]));
            return services;
        }
    }
}
