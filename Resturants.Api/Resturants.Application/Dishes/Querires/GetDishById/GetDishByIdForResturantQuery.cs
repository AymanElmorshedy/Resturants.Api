using MediatR;
using Resturants.Application.Dishes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Dishes.Querires.GetDishById
{
    public class GetDishByIdForResturantQuery(int resturantId,int dishId) : IRequest<DishDto>
    {
        public int ResturantId { get; } = resturantId;
        public int DishId { get; set; } = dishId;
    }
}
