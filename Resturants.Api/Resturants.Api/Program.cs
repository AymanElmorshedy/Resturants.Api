
using Resturants.Infrastructure.Persistence;
using Resturants.Infrastructure.Extentions;
using Resturants.Infrastructure.Seeders;
using Resturants.Application.Extentions;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Resturants.Api.Middlewares;
using Resturants.Domain.Entites;
using Microsoft.OpenApi.Models;
using Resturants.Api.Extentions;
namespace Resturants.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
   
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationService();
            builder.AddPresentations();
           
            var app = builder.Build();
            var Scoped = app.Services.CreateScope();
            var Seeder = Scoped.ServiceProvider.GetRequiredService<IResturantSeeder>();
            await Seeder.SeedAsync();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestTimeLoggingMiddleware>();

            app.UseSerilogRequestLogging();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapGroup("api/identity")
                .WithTags("Identity")
                .MapIdentityApi<User>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
