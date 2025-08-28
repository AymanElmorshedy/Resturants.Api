using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Commands.UpdateResturant
{
    public class UpdateResturantCommandHandler(ILogger<UpdateResturantCommandHandler> logger,
        IResturantRepository repository
        ,IMapper mapper) : IRequestHandler<UpdateResturantCommand, bool>
    {
        public async Task<bool> Handle(UpdateResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating resturant with id : {ResturantId} with {@UpdateResturant}",request.Id,request);
            var resturant = await repository.GetByIdAsync( request.Id );
            if(resturant is null ) return false;
            mapper.Map(request,resturant);
            await repository.UpdateAsync(resturant);
            return true;

            
        }
    }
}
