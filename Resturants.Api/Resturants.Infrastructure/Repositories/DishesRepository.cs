using Microsoft.EntityFrameworkCore;
using Resturants.Domain.Entites;
using Resturants.Domain.Repositories;
using Resturants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Infrastructure.Repositories
{
    public class DishesRepository(ResturantsDbContext dbContext) : IDishesRepository
    {
        public async Task<int> CreateAsync(Dish entity)
        {
            await dbContext.Dishes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;

        }

        public async Task Delete(IEnumerable<Dish> dishes)
        {
             dbContext.RemoveRange(dishes);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Dish?> GetByIdAsync(int id)
        {
            return  await dbContext.Dishes.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
