using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Application.Resturants.Dtos;
using Resturants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Queries.GetAllResturants
{
    public class GetAllResturantsQueryHandler(ILogger<GetAllResturantsQueryHandler> logger ,
        IMapper mapper ,IResturantRepository repository) : IRequestHandler<GetAllResturantsQuery, IEnumerable<ResturantDto>>
    {
        public async Task<IEnumerable<ResturantDto>> Handle(GetAllResturantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all resturants");
            var resturants = await repository.GetAllAsync();
            var resturantsDto = mapper.Map<IEnumerable<ResturantDto>>(resturants);
            return resturantsDto;
        }
    }
}
