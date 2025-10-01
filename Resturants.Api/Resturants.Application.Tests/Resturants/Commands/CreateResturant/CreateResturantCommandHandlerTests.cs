using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Resturants.Application.Resturants.Commands.CreateResturant;
using Resturants.Application.Users;
using Resturants.Domain.Entites;
using Resturants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Commands.CreateResturant.Tests
{
    [TestClass()]
    public class CreateResturantCommandHandlerTests
    {
        [TestMethod()]
        public async Task Handle_ForValidCommand_ReturnsCreatedResturantId()
        {
            //arrange
            var LoggerMock = new Mock<ILogger<CreateResturantCommandHandler>>();

            var command = new CreateResturantCommand();

            var mapper = new Mock<IMapper>();

            var resturant = new Resturant();
            mapper.Setup(m => m.Map<Resturant>(command)).Returns(resturant);
            var repository = new Mock<IResturantRepository>();
            repository.Setup(repo => repo.createAsync(It.IsAny<Resturant>()))// behavior of method
                .ReturnsAsync(1);
            var currentUser = new CurrentUser("Owner-id", "test@test.com", [], null, null);
            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.GetCurrentUser())
                .Returns(currentUser);
            var commandHandler = new CreateResturantCommandHandler
                ( 
                LoggerMock.Object,
                mapper.Object,
            repository.Object,
            userContext.Object
            );
            //act
           var result =await commandHandler.Handle(command, CancellationToken.None);
            //assert
            result.Should().Be(1);
            resturant.OwnerId.Should().Be("Owner-id");
            repository.Verify(r=>r.createAsync(resturant),Times.Once);

        }
    }
}