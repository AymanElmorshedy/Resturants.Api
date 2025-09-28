
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Application.Users;
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
        IMapper mapper,IResturantRepository repository
        ,IUserContext userContext) : IRequestHandler<CreateResturantCommand, int>
    {
        public async Task<int> Handle(CreateResturantCommand request, CancellationToken cancellationToken)
        {
            var CurrentUser = userContext.GetCurrentUser();
            logger.LogInformation("{UserName} :: [{UserId}]Creating a new resturant {@Resturant}",
                CurrentUser?.Email??"Unknown@exambel.com",
                CurrentUser?.Id??"uNKNOWNid",
                request);
            var resturant = mapper.Map<Resturant>(request);
            resturant.OwnerId = CurrentUser.Id;
            int id = await repository.createAsync(resturant);
            return id;
        }
    }
}
