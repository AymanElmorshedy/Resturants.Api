using FluentValidation;
using Resturants.Application.Resturants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Commands.CreateResturant
{
    public class CreateResturantCommandValidator : AbstractValidator<CreateResturantCommand>
    {
        private readonly List<string> ValidCategories = ["Italian", "Egyption", "Japanes", "American", "Indian"];
        public CreateResturantCommandValidator()
        {
            RuleFor(dto => dto.Name)
                .Length(3, 100);
            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description are required");
            RuleFor(dto => dto.Category)
                .Custom((value, context) =>
                {
                    var isValidateCategory = ValidCategories.Contains(value);
                    if (!isValidateCategory)
                    {
                        context.AddFailure("Category", "Invalid Category Please Chose from the valid category");
                    }
                });

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress()
                .WithMessage("Please provide a valid email address");


        }
    }
}
