using FluentValidation.TestHelper;
using Xunit;

namespace Resturants.Application.Resturants.Commands.CreateResturant.Tests;

public class CreateResturantCommandValidatorTests
{
    [Fact()]
    public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
    {
        //Arrange
        var command = new CreateResturantCommand()
        {
            Name="Test",
            Category = "Italian",
            Description = "Test Description",
            ContactEmail="test@test.com"

        };
        var validator = new CreateResturantCommandValidator();
        //Act
        var result =  validator.TestValidate(command);
        //Assert
        result.ShouldNotHaveAnyValidationErrors();

    }
    [Fact()]
    public void Validator_ForValidCommand_ShouldHaveValidationErrors()
    {
        //Arrange
        var command = new CreateResturantCommand()
        {
            Name = "Te",
            Category = "Spanish",
            Description = "Test Description",
            ContactEmail = "test.com"

        };
        var validator = new CreateResturantCommandValidator();
        //Act
        var result = validator.TestValidate(command);
        //Assert
        result.ShouldHaveValidationErrorFor(c=>c.Name);
        result.ShouldHaveValidationErrorFor(c=>c.Category);
        result.ShouldHaveValidationErrorFor(c=>c.ContactEmail);

    }
    [Theory]
    [InlineData("Italian")]
    [InlineData("Egyption")]
    [InlineData("Japanes")]
    [InlineData("American")]
    [InlineData("Indian")]
    public void Validator_ForCategory_ShouldNotHaveValidationError(string category)
    {
        //Arrange
        var validator = new CreateResturantCommandValidator();
        var command = new CreateResturantCommand{Category=category};
        //Act
        var result = validator.TestValidate(command);
        //Assert
        result.ShouldNotHaveValidationErrorFor(c => c.Category);
    }
}