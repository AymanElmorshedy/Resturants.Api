using Xunit;
using Resturants.Application.Resturants.Commands.UpdateResturant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Resturants.Domain.Repositories;
using AutoMapper;
using Resturants.Domain.Interfaces;
using Resturants.Domain.Entites;
using Resturants.Domain.Constants;
using Resturants.Domain.Exceptions;
using FluentAssertions;

namespace Resturants.Application.Resturants.Commands.UpdateResturant.Tests
{
    public class UpdateResturantCommandHandlerTests
    {
        private readonly Mock<ILogger<UpdateResturantCommandHandler>> _loggerMock;
        private readonly Mock<IResturantRepository> _resturantRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IResturantAuthorizationService> _authorizationServiceMock;
        private readonly UpdateResturantCommandHandler _handler;


        public UpdateResturantCommandHandlerTests()
        {
            _loggerMock = new Mock<ILogger<UpdateResturantCommandHandler>>();
            _resturantRepositoryMock = new Mock<IResturantRepository>();
            _mapperMock = new Mock<IMapper>();
            _authorizationServiceMock = new Mock<IResturantAuthorizationService>();

            _handler = new UpdateResturantCommandHandler(
                _loggerMock.Object,
                _resturantRepositoryMock.Object,
                _mapperMock.Object,
                _authorizationServiceMock.Object
            );

        }

        [Fact()]
        public async Task Handle_WithValidRequest_ShouldUpdateResturants()
        {
            var resturantId = 1;
            var command = new UpdateResturantCommand
            {
                Id = resturantId,
                Name = "Updated Resturant",
                Description = "Updated Description",
                HasDelivery = true,

            };
            var resturant = new Resturant
            {
                Id = resturantId,
                Name = "Test",
                Description = "Test",


            };

            _resturantRepositoryMock.Setup(r => r.GetByIdAsync(resturantId))
                .ReturnsAsync(resturant);
            _authorizationServiceMock.Setup(m => m.Authorize(resturant, ResourceOperation.Update)).Returns(true);
            //        _authorizationServiceMock
            //.Setup(m => m.Authorize(It.IsAny<Resturant>(), ResourceOperation.Update))
            //.Returns(true);

            //act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _resturantRepositoryMock.Verify(r => r.GetByIdAsync(resturantId), Times.Once);
            _mapperMock.Verify(m => m.Map(command, resturant), Times.Once);
            //_resturantRepositoryMock.Verify(r => r.UpdateAsync(resturant), Times.Once);

        }
        [Fact()]
        public async Task Handel_WithNonExistingResturant_ShouldThrownNotFoundException()
        {
            var resturantId = 2;
            var request = new UpdateResturantCommand
            {
                Id = resturantId

            };
            _resturantRepositoryMock.Setup(r => r.GetByIdAsync(resturantId))
                .ReturnsAsync((Resturant?)null);

            //act

            Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

            //assert
            //await act.Should().ThrowAsync<NotFoundException>()
            //    .WithMessage($"Resturant with id : {resturantId}  doesn't exist");
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .Where(ex => ex.Message.Contains("Resturant with id")
                         && ex.Message.Contains("2")
                            && ex.Message.Contains("doesn't exist"));

        }
        [Fact()]
        public async Task Handle_WhenAuthorizationFails_ShouldThrowForbidException()
        {
            // Arrange
            var resturantId = 3;
            var command = new UpdateResturantCommand
            {
                Id = resturantId,

            };
            var resturant = new Resturant
            {
                Id = resturantId,

            };
            _resturantRepositoryMock.Setup(r => r.GetByIdAsync(resturantId))
                .ReturnsAsync(resturant);
            _authorizationServiceMock.Setup(m => m.Authorize(resturant, ResourceOperation.Update)).Returns(false);

            // Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);
            // Assert
            await act.Should().ThrowAsync<ForbidException>();
        }
    }
}