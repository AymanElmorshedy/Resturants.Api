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

namespace Resturants.Application.Dishes.Querires.GetDishById
{
    public class GetDishByIdForResturantQueryHandler(ILogger<GetDishByIdForResturantQueryHandler> logger ,
        IResturantRepository resturantRepository 
        ,IDishesRepository dishesRepository
        ,IMapper mapper) : IRequestHandler<GetDishByIdForResturantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdForResturantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Retriving dish :{request.DishId},for resturant with id : {request.ResturantId}");
            var resturant = await resturantRepository.GetByIdAsync(request.ResturantId);
            if (resturant is null) throw new NotFoundException(nameof(Resturant), request.ResturantId.ToString());
            var dish = await dishesRepository.GetByIdAsync(request.DishId);
            if(dish is null) throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            var result  = mapper.Map<DishDto>(dish);
            return result;

        }
    }
}
