using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Application.Common;
using Resturants.Application.Resturants.Dtos;
using Resturants.Domain.Entites;
using Resturants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Queries.GetAllResturants
{
    public class GetAllResturantsQueryHandler(ILogger<GetAllResturantsQueryHandler> logger ,
        IMapper mapper ,IResturantRepository repository) : IRequestHandler<GetAllResturantsQuery, PagedResult<ResturantDto>>
    {
        public async Task<PagedResult<ResturantDto>> Handle(GetAllResturantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all resturants");
            (IEnumerable<Resturant> resturants, int totalcount) = await repository.GetAllMatchingAsync(request.SearchPhrase,
                request.PageSize,request.PageNumber,request.SortBy,request.SortDirection);
            var resturantsDto = mapper.Map<IEnumerable<ResturantDto>>(resturants);
            var result = new PagedResult<ResturantDto>(resturantsDto,totalcount
                ,request.PageSize
                ,request.PageNumber);
        
            return result;
        }
    }
}
