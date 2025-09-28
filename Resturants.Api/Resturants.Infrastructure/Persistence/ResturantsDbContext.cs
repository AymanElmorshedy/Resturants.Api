using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturants.Domain.Entites;
namespace Resturants.Infrastructure.Persistence
{
    public class ResturantsDbContext(DbContextOptions<ResturantsDbContext> options) 
        : IdentityDbContext<User>(options)
    {
        
        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Resturant>()
               . OwnsOne(r=>r.Address);
            modelBuilder.Entity<Resturant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.ResturantId);
            modelBuilder.Entity<User>()
                .HasMany(u=> u.OwnedResturant)
                .WithOne(r => r.Owner)
                .HasForeignKey(r => r.OwnerId);



        }

    }
}
