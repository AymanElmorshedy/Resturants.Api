using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Resturants.Application.Profiles;
using Resturants.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IResturantsService, ResturantsService>();
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(AssemplyRreference).Assembly));
            services.AddValidatorsFromAssembly(typeof(AssemplyRreference).Assembly)
                .AddFluentValidationAutoValidation();
        }
    }
}
