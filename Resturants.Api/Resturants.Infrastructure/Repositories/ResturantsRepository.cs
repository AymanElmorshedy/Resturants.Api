using Microsoft.EntityFrameworkCore;
using Resturants.Application.Common;
using Resturants.Domain.Constants;
using Resturants.Domain.Entites;
using Resturants.Domain.Repositories;
using Resturants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<(IEnumerable<Resturant>,int)> GetAllMatchingAsync(string? srearchPhase,int PageSize,int PageIndex,string? sortBy,SortDirection sortDirection)
        {
            var SearchPhaseLower = srearchPhase?.ToLower();
            var baseQuery =  _dbContext.Resturants
                .Where(r => (SearchPhaseLower == null) || (r.Name.ToLower().Contains(SearchPhaseLower) ||
                r.Description.ToLower().Contains(SearchPhaseLower)));
            var totalCount =await baseQuery.CountAsync();
            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Resturant, object>>>
                {
                    { nameof(Resturant.Name), r => r.Name },
                    { nameof(Resturant.Description), r => r.Description },
                    { nameof(Resturant.Category), r => r.Category },
                };
                var selectedColumn = columnsSelector[sortBy];
                baseQuery = sortDirection == SortDirection.Ascending ?
                    baseQuery.OrderBy(selectedColumn) :
                    baseQuery.OrderByDescending(selectedColumn);
            }

            var Resturants = await baseQuery
                .Skip(PageSize * (PageIndex - 1))
                .Take(PageSize) 
                .ToListAsync();
            return( Resturants,totalCount);
        }

        public async Task<Resturant?> GetByIdAsync(int id)
        {
            var Resturant =await _dbContext.Resturants
                .Include(r=>r.Dishes)
                .FirstOrDefaultAsync(r=>r.Id==id);
            return Resturant;
            
        }

        public async Task UpdateAsync(Resturant resturant)
        {
            _dbContext.Resturants.Update(resturant);
            await _dbContext.SaveChangesAsync();
        }
    }
}
