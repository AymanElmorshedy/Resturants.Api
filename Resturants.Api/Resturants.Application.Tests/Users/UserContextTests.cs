using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Resturants.Domain.Constants;
using FluentAssertions;
using System.Diagnostics.Contracts;

namespace Resturants.Application.Users.Tests;

public class UserContextTests
{
    [Fact()]
    public void GetCurrentUser_WithAuthinticatedUser_ShouldReturnCurrentUserObject()
    {
        //arrange
        var dateOfBirth = new DateOnly(2000, 1, 1);
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier,"1"),
            new(ClaimTypes.Email,"test@test.com"),
            new(ClaimTypes.Role,UserRoles.Admin),
            new(ClaimTypes.Role,UserRoles.User),
            new("Nationality","German"),
            new("DateOfBirth",dateOfBirth.ToString("yyyy-MM-dd"))
        };
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims,"Test"));
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext() { User = user });
        var userContext = new UserContext(httpContextAccessorMock.Object);
        //act
        var currentUser = userContext.GetCurrentUser(); 
        //assert
        currentUser.Should().NotBeNull();
        currentUser.Id.Should().Be("1");
        currentUser.Email.Should().Be("test@test.com");
        currentUser.Roles.Should().ContainInOrder( UserRoles.Admin, UserRoles.User );
        currentUser.Nationality.Should().Be("German");
        currentUser.DateOfBirth.Should().Be(dateOfBirth);
    }
    [Fact()]
    public void GetCurrentUser_WithUserContextNotPresent_ThrowsInvalidOperationException()
    {
        //Arange
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns((HttpContext)null);
        var userContext = new UserContext(httpContextAccessorMock.Object);
        //Act
        Action act = () => userContext.GetCurrentUser();
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("User context is not present");
    }
}