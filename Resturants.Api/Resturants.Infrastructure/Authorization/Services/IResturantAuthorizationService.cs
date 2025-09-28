using Resturants.Domain.Entites;

namespace Resturants.Infrastructure.Authorization.Services
{
    public interface IResturantAuthorizationService
    {
        bool Authorize(Resturant resturant, ResourceOperation resourceOperation);
    }
}