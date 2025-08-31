using Resturants.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Domain.Repositories
{
    public interface IDishesRepository
    {
        Task<int> CreateAsync(Dish entity);
    }
}
