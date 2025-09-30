using FluentAssertions;
using Resturants.Domain.Constants;
using Xunit;

namespace Resturants.Application.Users.Tests;

public class CurrentUserTests
{
    //TestMethod_Scenario_ExpectedResult
    //[Fact()]
    [Theory]
    [InlineData(UserRoles.Admin)]
    [InlineData(UserRoles.User)]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue(string roleName)
    {
        //arrange
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin,UserRoles.User],null,null);
        //act
        var isInRole = currentUser.IsInRole(roleName);
        //assert
        isInRole.Should().BeTrue();
    }
    [Fact()]    
    public void IsInRole_WithNoMatchingRole_ShouldReturnFalse()
    {
        //arrange => Preaparing the data
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);
        //act => Executing the method to be tested
        var isInRole = currentUser.IsInRole(UserRoles.Owner);
        //assert => Verifying the result    
        isInRole.Should().BeFalse();
    }
    [Fact()]
    public void IsInRole_WithNoMatchingRoleCase_ShouldReturnFalse()
    {
        //arrange
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);
        //act
        var isInRole = currentUser.IsInRole(UserRoles.Owner.ToLower());
        //assert
        isInRole.Should().BeFalse();
    }
}