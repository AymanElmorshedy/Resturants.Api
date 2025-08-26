using AutoMapper;
using Microsoft.Extensions.Logging;
using Resturants.Application.Dtos.Resturant;
using Resturants.Domain.Entites;
using Resturants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Services
{
    public class ResturantsService(IResturantRepository repository, ILogger<ResturantsService> logger
        , IMapper mapper) : IResturantsService
    {
        public async Task<int> CreateResturantAsync(CreateResturantDto createResturantDto)
        {
            logger.LogInformation("Creating a new resturant");
            var resturant = mapper.Map<Resturant>(createResturantDto);
           int id = await repository.createAsync(resturant);
            return id;
        }

        public async Task<IEnumerable<ResturantDto>> GetAllResturantsAsync()
        {
            logger.LogInformation("Getting all resturants");
            var resturants = await repository.GetAllAsync();
            var resturantsDto = mapper.Map<IEnumerable<ResturantDto>>(resturants);
            return resturantsDto;
        }

        public async Task<ResturantDto?> GetByIdAsync(int id)
        {
            logger.LogInformation($"Getting Resturant of {id}");
            var Resturant =await repository.GetById(id);
            var resturantDto = mapper.Map<ResturantDto?>(Resturant);
            return resturantDto;
        }
    }
}
