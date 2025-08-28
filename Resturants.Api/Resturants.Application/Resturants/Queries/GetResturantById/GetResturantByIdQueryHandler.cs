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

namespace Resturants.Application.Resturants.Queries.GetResturantById
{
    public class GetResturantByIdQueryHandler(IResturantRepository repository
        ,IMapper mapper,ILogger<GetResturantByIdQueryHandler> logger) : IRequestHandler<GetResturantByIdQuery, ResturantDto?>
    {
        public async Task<ResturantDto?> Handle(GetResturantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting Resturant of {ResturantId}",request.Id);
            var Resturant = await repository.GetByIdAsync(request.Id);
            var resturantDto = mapper.Map<ResturantDto?>(Resturant);
            return resturantDto;
        }
    }
}
