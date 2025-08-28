
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Entites;
using Resturants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Commands.CreateResturant
{
    public class CreateResturantCommandHandler(ILogger<CreateResturantCommandHandler> logger,
        IMapper mapper,IResturantRepository repository) : IRequestHandler<CreateResturantCommand, int>
    {
        public async Task<int> Handle(CreateResturantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new resturant {@Resturant}",request);
            var resturant = mapper.Map<Resturant>(request);
            int id = await repository.createAsync(resturant);
            return id;
        }
    }
}
