
using Resturants.Infrastructure.Persistence;
using Resturants.Infrastructure.Extentions;
using Resturants.Infrastructure.Seeders;
namespace Resturants.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructureServices(builder.Configuration);

            var app = builder.Build();
            var Scoped = app.Services.CreateScope();
            var Seeder=  Scoped.ServiceProvider.GetRequiredService<IResturantSeeder>();
           await Seeder.SeedAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
