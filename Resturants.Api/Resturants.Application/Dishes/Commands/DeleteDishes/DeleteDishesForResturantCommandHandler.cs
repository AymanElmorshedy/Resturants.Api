using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entites;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Repositories;
using Resturants.Infrastructure.Authorization;
using Resturants.Infrastructure.Authorization.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishesForResturantCommandHandler(ILogger<DeleteDishesForResturantCommandHandler> logger
        ,IResturantRepository resturantRepository
        ,IDishesRepository dishesRepository
        ,IResturantAuthorizationService resturantAuthorizationService) : IRequestHandler<DeleteDishesForResturantCommand>
    {
        public async Task Handle(DeleteDishesForResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogWarning($"Removing all dishes from resturant with id : {request.ResturantId}");
            var resturant = await resturantRepository.GetByIdAsync(request.ResturantId);
            if (resturant is null) throw new NotFoundException(nameof(Resturant), request.ResturantId.ToString());
            if (!resturantAuthorizationService.Authorize(resturant, ResourceOperation.Delete))
            {
                throw new ForbidException();
            }
            await dishesRepository.Delete(resturant.Dishes);
        }
    }
}
