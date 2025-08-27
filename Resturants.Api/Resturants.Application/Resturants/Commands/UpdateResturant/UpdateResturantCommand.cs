using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Commands.UpdateResturant
{
    public class UpdateResturantCommand : IRequest<bool>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDelivery { get; set; }

    }
}
