using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Commands.DeleteResturant
{
    public class DeleteResturantCommandHandler(ILogger<DeleteResturantCommandHandler> logger) : IRequestHandler<DeleteResturantCommand>
    {
        public Task Handle(DeleteResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting resturant with id : {request.Id}"); 
        }
    }
}
