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
        Task<IEnumerable<Resturant>> GetAllAsync();
        Task<Resturant?> GetById(int id);
    }
}
