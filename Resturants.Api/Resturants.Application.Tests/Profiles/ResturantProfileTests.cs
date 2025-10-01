using Xunit;
using AutoMapper;
using Resturants.Application.Profiles;
using System.Collections.Generic;
using Microsoft.Extensions.Logging.Abstractions;
using Resturants.Domain.Entites;
using Resturants.Application.Resturants.Dtos;
using FluentAssertions;
using Resturants.Application.Resturants.Commands.CreateResturant;
using Resturants.Application.Resturants.Commands.UpdateResturant;

namespace Resturants.Application.Profiles.Tests
{
    public class ResturantProfileTests
    {
        private  IMapper _mapper;
        public ResturantProfileTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ResturantProfile>();
            }, new NullLoggerFactory());

             _mapper = config.CreateMapper();
        }


        [Fact()]
        public void CreateMap_ForResturantToResturantDto_MapsCorrectly()
        {
            // Arrange  
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<ResturantProfile>();
    
            var resturant = new Resturant
            {
                Id = 1,
                Name = "Test Resturant",
                Description = "A test resturant",
                HasDelivery=true,
                Address = new Domain.Entites.Address
                {
                    City = "Test City",
                    Street = "123 Test St",
                    PostalCode = "12345"
                },
               
            };
            //Act
            var resturantDto = _mapper.Map<ResturantDto>(resturant);
            //Assert
            resturantDto.Should().NotBeNull();
            resturantDto.Id.Should().Be(resturant.Id);
            resturantDto.Name.Should().Be(resturant.Name);
            resturantDto.Description.Should().Be(resturant.Description);
            resturantDto.City.Should().Be(resturant.Address.City);
            resturantDto.Street.Should().Be(resturant.Address.Street);
            resturantDto.PostalCode.Should().Be(resturant.Address.PostalCode);

            resturantDto.HasDelivery.Should().Be(resturant.HasDelivery);
        }
        [Fact()]
        public void CreateMap_ForCreateResturantCommandToResturant_MapsCorrectly()
        {
       
            var command = new CreateResturantCommand
            {
                Name = "Test Resturant",
                Description = "A test resturant",
                HasDelivery = true,
                City = "Test City",
                Street = "123 Test St",
                PostalCode = "12345",
                Category="TestCategory",
                ContactEmail="test@test.com",
                


            };
            //Act
            var resturant = _mapper.Map<Resturant>(command);
            //Assert
            resturant.Should().NotBeNull();
            resturant.Name.Should().Be(command.Name);
            resturant.Description.Should().Be(command.Description);
            resturant.HasDelivery.Should().Be(command.HasDelivery);
            resturant.Address.City.Should().Be(command.City);
            resturant.Address.Street.Should().Be(command.Street);
            resturant.Address.PostalCode.Should().Be(command.PostalCode);
            resturant.Category.Should().Be(command.Category);
            resturant.ContactEmail.Should().Be(command.ContactEmail);


        }
        [Fact()]
        public void CreateMap_ForUpdateResturantCommandToResturant_MapsCorrectly()
        {

            var command = new UpdateResturantCommand
            {
                Id=1,
                Name = "Test Resturant",
                Description = "A test resturant",
                HasDelivery = true
            };
            //Act
            var resturant = _mapper.Map<Resturant>(command);
            //Assert
            resturant.Should().NotBeNull();
            resturant.Id.Should().Be(command.Id);
            resturant.Name.Should().Be(command.Name);
            resturant.Description.Should().Be(command.Description);
            resturant.HasDelivery.Should().Be(command.HasDelivery);



        }
    }
}