using Microsoft.EntityFrameworkCore;
using Resturants.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Infrastructure.Persistence
{
    public class ResturantsDbContext : DbContext
    {
        public ResturantsDbContext(DbContextOptions<ResturantsDbContext>options):base(options) 
        {
            
        }
        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resturant>()
               . OwnsOne(r=>r.Address);
            modelBuilder.Entity<Resturant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.ResturantId);
        }

    }
}
