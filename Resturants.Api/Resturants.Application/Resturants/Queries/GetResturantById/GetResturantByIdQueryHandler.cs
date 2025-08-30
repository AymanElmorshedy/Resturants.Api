using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Application.Resturants.Dtos;
using Resturants.Domain.Entites;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Queries.GetResturantById
{
    public class GetResturantByIdQueryHandler(IResturantRepository repository
        ,IMapper mapper,ILogger<GetResturantByIdQueryHandler> logger) : IRequestHandler<GetResturantByIdQuery, ResturantDto>
    {
        public async Task<ResturantDto> Handle(GetResturantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting Resturant of {ResturantId}",request.Id);
            var resturant = await repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(nameof(Resturant), request.Id.ToString());
            var resturantDto = mapper.Map<ResturantDto>(resturant);
            return resturantDto;
        }
    }
}
