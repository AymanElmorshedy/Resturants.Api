using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Commands.DeleteResturant
{
    public class DeleteResturantCommand(int id) :IRequest
    {
        public int Id { get;  }=id;
    }
}
