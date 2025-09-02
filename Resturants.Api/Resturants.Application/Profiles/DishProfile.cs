using AutoMapper;
using Resturants.Application.Dishes.Commands.CreateDish;
using Resturants.Application.Dishes.Dtos;
using Resturants.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish,DishDto>();
            CreateMap<CreateDishCommand, Dish>();

             
        }
    }
}
