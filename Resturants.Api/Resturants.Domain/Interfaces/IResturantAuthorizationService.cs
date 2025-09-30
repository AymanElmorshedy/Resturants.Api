using Resturants.Domain.Constants;
using Resturants.Domain.Entites;


namespace Resturants.Domain.Interfaces
{
    public interface IResturantAuthorizationService
    {
        bool Authorize(Resturant resturant, ResourceOperation resourceOperation);
    }
}