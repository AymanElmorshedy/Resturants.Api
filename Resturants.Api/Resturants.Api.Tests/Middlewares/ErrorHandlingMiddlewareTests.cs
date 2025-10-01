using Xunit;
using Resturants.Api.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Moq;
using Resturants.Domain.Exceptions;
using Resturants.Domain.Entites;
using FluentAssertions;

namespace Resturants.Api.Middlewares.Tests
{
    public class ErrorHandlingMiddlewareTests
    {

        [Fact()]
        public async Task InvokeAsync_WhenNoExceptionThrown_ShouldCallTheNextDelegate()
        {
            //ARRANGE 
            var loggerMock = new Moq.Mock<ILogger<ErrorHandlingMiddleware>>();
            var middleware = new ErrorHandlingMiddleware(loggerMock.Object);
            var context = new DefaultHttpContext();
            var nextDelegateMock = new Mock<RequestDelegate>();
            // Act
            await middleware.InvokeAsync(context,nextDelegateMock.Object);
            // Assert
            nextDelegateMock.Verify(next=>next.Invoke(context),Times.Once);


        }
        [Fact()]
        public async Task InvokeAsync_WhenNotFoundExceptionThrown_ShouldSetStattusCodeTO404AndWriteExceptionMessage()
        {
            var loggerMock = new Moq.Mock<ILogger<ErrorHandlingMiddleware>>();
            var middleware = new ErrorHandlingMiddleware(loggerMock.Object);
            var context = new DefaultHttpContext();
            var notFoundException = new NotFoundException(nameof(Resturant), "1");
            //act
            await middleware.InvokeAsync(context, (innerHttpContext) => throw notFoundException);
            //Assert 
            context.Response.StatusCode.Should().Be(404);
        }
        [Fact()]
        public async Task InvokeAsync_WhenForbidenExceptionThrown_ShouldSetStattusCodeTO403()
        {
            var loggerMock = new Moq.Mock<ILogger<ErrorHandlingMiddleware>>();
            var middleware = new ErrorHandlingMiddleware(loggerMock.Object);
            var context = new DefaultHttpContext();
            var exception = new ForbidException();
            //act
            await middleware.InvokeAsync(context, _=>throw exception );
            //Assert 
            context.Response.StatusCode.Should().Be(403);
        }
        [Fact()]
        public async Task InvokeAsync_WhenGenericExceptionThrown_ShouldSetStattusCodeTO500()
        {
            var loggerMock = new Moq.Mock<ILogger<ErrorHandlingMiddleware>>();
            var middleware = new ErrorHandlingMiddleware(loggerMock.Object);
            var context = new DefaultHttpContext();
            var exception = new Exception();
            //act
            await middleware.InvokeAsync(context, _ => throw exception);
            //Assert 
            context.Response.StatusCode.Should().Be(500);
        }
    }
}