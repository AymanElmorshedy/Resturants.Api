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
    public class DishesRepository(ResturantsDbContext dbContext ) : IDishesRepository
    {
        public async Task<int> CreateAsync(Dish entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;

        }
    }
}
