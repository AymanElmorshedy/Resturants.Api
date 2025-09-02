using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resturants.Domain.Repositories;
using Resturants.Infrastructure.Persistence;
using Resturants.Infrastructure.Repositories;
using Resturants.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Infrastructure.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ResturantsDbContext>
                (options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging();
                });
            services.AddScoped<IResturantSeeder, ResturantSeeder>();
            services.AddScoped<IResturantRepository,ResturantsRepository>();
            services.AddScoped<IDishesRepository,DishesRepository>();
        }
    }
}

