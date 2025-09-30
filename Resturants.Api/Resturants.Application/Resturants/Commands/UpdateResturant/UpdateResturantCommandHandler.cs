using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entites;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Repositories;
//using Resturants.Infrastructure.Authorization.Services;
using Resturants.Infrastructure.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Resturants.Domain.Interfaces;
using Resturants.Domain.Constants;

namespace Resturants.Application.Resturants.Commands.UpdateResturant
{
    public class UpdateResturantCommandHandler(ILogger<UpdateResturantCommandHandler> logger,
        IResturantRepository repository
        ,IMapper mapper
        ,IResturantAuthorizationService resturantAuthorizationService ) : IRequestHandler<UpdateResturantCommand>
    {
        public async Task Handle(UpdateResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating resturant with id : {ResturantId} with {@UpdateResturant}",request.Id,request);
            var resturant = await repository.GetByIdAsync( request.Id );
            if(resturant is null) throw new NotFoundException(nameof(Resturant),request.Id.ToString());
            mapper.Map(request,resturant);
            if (!resturantAuthorizationService.Authorize(resturant, ResourceOperation.Delete) )
            {
                throw new ForbidException();
            }
            await repository.UpdateAsync(resturant);
            
            

            
        }
    }
}
