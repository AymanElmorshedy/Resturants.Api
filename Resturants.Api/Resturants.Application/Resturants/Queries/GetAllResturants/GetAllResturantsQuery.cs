using MediatR;
using Resturants.Application.Resturants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Queries.GetAllResturants
{
    public class GetAllResturantsQuery : IRequest<IEnumerable<ResturantDto>>
    {
        public string? SearchPhrase { get; set; }

    }
}
