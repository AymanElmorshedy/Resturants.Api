using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Application.Dishes.Dtos;
using Resturants.Domain.Entites;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Dishes.Querires.GetAllDishes
{
    public class GetDishesForResturantQueryHandler(ILogger<GetDishesForResturantQuery> logger
        , IResturantRepository resturantRepository,
        IMapper mapper) : IRequestHandler<GetDishesForResturantQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetDishesForResturantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Retriving Dishes For Resturant with id {request.ResturantId}");
            var resturant = await resturantRepository.GetByIdAsync(request.ResturantId);
            if (resturant is null) throw new NotFoundException(nameof(Resturant), request.ResturantId.ToString());
            var result = mapper.Map<IEnumerable<DishDto>>(resturant.Dishes);
            return result;

        }
    }
}
