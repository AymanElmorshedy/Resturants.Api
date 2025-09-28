using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resturants.Domain.Entites;
using Resturants.Domain.Repositories;
using Resturants.Infrastructure.Authorization.Constants;
using Resturants.Infrastructure.Authorization.Requirment;
using Resturants.Infrastructure.Authorization.Services;
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
            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User>>()
                .AddEntityFrameworkStores<ResturantsDbContext>();
            services.AddAuthorizationBuilder()
                .AddPolicy(PolicyNames.HasNAtionality, builder => builder.RequireClaim(AppClaimTypes.Nationality))
                .AddPolicy(PolicyNames.AtLeast15,
                builder=>builder.AddRequirements(new MinimumAgeRequirment(15)));
            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirmentHandler>();
            services.AddScoped<IResturantAuthorizationService, ResturantAuthorizationService>();


        }
    }
}

