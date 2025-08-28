using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Commands.DeleteResturant
{
    public class DeleteResturantCommandHandler(ILogger<DeleteResturantCommandHandler> logger,
        IResturantRepository repository) : IRequestHandler<DeleteResturantCommand,bool>
    {
        public async Task<bool> Handle(DeleteResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting resturant with id : {ResturantId} ",request.Id); 
            var restursnt = await repository.GetByIdAsync( request.Id );
            if( restursnt is null ) return false;
           await repository.DeleteAsync( restursnt );
            return true;
        }

      
    }
}
