using MediatR;
using Resturants.Application.Resturants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Queries.GetResturantById
{
    public class GetResturantByIdQuery(int id) : IRequest<ResturantDto>
    {
        public int Id { get;  } = id;

    }
}
