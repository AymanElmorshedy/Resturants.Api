using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Constants;
using Resturants.Domain.Entites;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Interfaces;
using Resturants.Domain.Repositories;
using Resturants.Infrastructure.Authorization;
//using Resturants.Infrastructure.Authorization.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Commands.DeleteResturant
{
    public class DeleteResturantCommandHandler(ILogger<DeleteResturantCommandHandler> logger,
        IResturantRepository repository
        , IResturantAuthorizationService resturantAuthorizationService) : IRequestHandler<DeleteResturantCommand>
    {
        public async Task Handle(DeleteResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting resturant with id : {ResturantId} ", request.Id);
            var restursnt = await repository.GetByIdAsync(request.Id);
            if (restursnt is null) throw new NotFoundException(nameof(Resturant), request.Id.ToString());
            if (!resturantAuthorizationService.Authorize(restursnt, ResourceOperation.Update))
            {
                throw new ForbidException();
            }
            await repository.DeleteAsync(restursnt);

        }


    }
}
