using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishesForResturantCommand(int resturantId) : IRequest
    {
        public int ResturantId { get;  }=resturantId;
    }
}
