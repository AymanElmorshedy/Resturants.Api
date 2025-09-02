using MediatR;
using Resturants.Application.Dishes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Dishes.Querires.GetAllDishes
{
    public class GetDishesForResturantQuery(int resturantId) : IRequest<IEnumerable<DishDto>>
    {
        public int ResturantId { get; } = resturantId;
    }
}
