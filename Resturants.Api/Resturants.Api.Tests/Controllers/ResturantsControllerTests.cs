using Xunit;
using Resturants.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace Resturants.Api.Controllers.Tests
{
    public class ResturantsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public ResturantsControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
        }
 
        [Fact()]
        public async Task GetAll_ForValidRequest_Returns200Ok()
        {
            //arrange
            var client = _factory.CreateClient();
            //act 
            var result = await client.GetAsync("/api/resturants?pageNumber=1&pageSize=10");
            //assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
        [Fact()]
        public async Task GetAll_ForIncalidRequest_Returns400BadRequest()
        {
            //arrange
            var client = _factory.CreateClient();
            //act 
            var result = await client.GetAsync("/api/resturants");
            //assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}