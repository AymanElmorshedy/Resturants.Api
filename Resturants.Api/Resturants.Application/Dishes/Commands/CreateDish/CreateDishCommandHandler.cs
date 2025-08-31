using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entites;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger
        ,IResturantRepository resturantRepository
        ,IDishesRepository dishesRepository
        ,IMapper mapper ) : IRequestHandler<CreateDishCommand>
    {
        public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new dish : {@DishRequest}", request);
            var resturant = await resturantRepository.GetByIdAsync(request.ResturantId);
            if (resturant == null) throw new NotFoundException(nameof(Resturant),request.ResturantId.ToString());
            var dish = mapper.Map<Dish>(request);
            await dishesRepository.CreateAsync(dish);
        }
    }
}
