using Resturants.Application.Dtos.Resturant;
using Resturants.Domain.Entites;

namespace Resturants.Application.Services
{
    public interface IResturantsService
    {
        Task<int> CreateResturantAsync(CreateResturantDto createResturantDto);
        Task<IEnumerable<ResturantDto>> GetAllResturantsAsync();
        Task<ResturantDto?> GetByIdAsync(int id);
    }
}