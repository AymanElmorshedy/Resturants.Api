using MediatR;
using Resturants.Application.Common;
using Resturants.Application.Resturants.Dtos;
using Resturants.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Queries.GetAllResturants
{
    public class GetAllResturantsQuery : IRequest<PagedResult<ResturantDto>>
    {
        public string? SearchPhrase { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }



    }
}
