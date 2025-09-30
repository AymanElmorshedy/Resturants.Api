using Resturants.Domain.Constants;
using Resturants.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Domain.Repositories
{
    public interface IResturantRepository
    {
        Task<int> createAsync(Resturant resturant);
        Task DeleteAsync(Resturant restursnt);
        Task<IEnumerable<Resturant>> GetAllAsync();
        Task<Resturant?> GetByIdAsync(int id);
        Task UpdateAsync(Resturant resturant);
        Task<(IEnumerable<Resturant>, int)> GetAllMatchingAsync(string? srearchPhase,int PageSize,int PageIndex,string? sortBy,SortDirection sortDirection);

    }
}
