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
    public class ResturantsRepository(ResturantsDbContext _dbContext) 
        : IResturantRepository
    {
        public async Task<int> createAsync(Resturant resturant)
        {
            await _dbContext.AddAsync(resturant);
            await _dbContext.SaveChangesAsync();
            return resturant.Id;
        }

        public async Task DeleteAsync(Resturant restursnt)
        {
            _dbContext.Remove(restursnt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Resturant>> GetAllAsync()
        {
            var Resturants =await _dbContext.Resturants.ToListAsync();
            return Resturants;
        }

        public async Task<Resturant?> GetById(int id)
        {
            var Resturant =await _dbContext.Resturants
                .Include(r=>r.Dishes)
                .FirstOrDefaultAsync(r=>r.Id==id);
            return Resturant;
            
        }
    }
}
