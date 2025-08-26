using AutoMapper;
using Resturants.Application.Dtos.Resturant;
using Resturants.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Profiles
{
    public class ResturantProfile : Profile
    {
        public ResturantProfile()
        {
            CreateMap<Resturant, ResturantDto>()
            .ForMember(dest => dest.City,
            options =>
            options.MapFrom(src => src.Address == null ? null : src.Address.City))
             .ForMember(dest => dest.Street,
            options =>
            options.MapFrom(src => src.Address == null ? null : src.Address.Street))
              .ForMember(dest => dest.PostalCode,
            options =>
            options.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
              .ForMember(dest => dest.Dishes,
              options =>
              options.MapFrom(src => src.Dishes))
                .ReverseMap();
            CreateMap<CreateResturantDto, Resturant>()
                .ForMember(dest => dest.Address, options =>
                options.MapFrom(
                    src => new Address()
                    {
                        Street = src.Street,
                        PostalCode = src.PostalCode,
                        City = src.City,

                    }));
        }
    }
}
