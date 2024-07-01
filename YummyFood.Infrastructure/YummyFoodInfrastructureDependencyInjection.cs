﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Infrastructure.Persistance;

namespace YummyFood.Infrastructure
{
    public static class YummyFoodInfrastructureDependencyInjection
    {
        public static IServiceCollection AddYummyFoodInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, YummyFoodDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnenction"));
            });
            
            return services;
        }
    }
}
