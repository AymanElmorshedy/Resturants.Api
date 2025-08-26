using FluentValidation;
using Resturants.Application.Dtos.Resturant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Validators.Resturant
{
    public class CreateResturantDtoValidator :AbstractValidator<CreateResturantDto>
    {
        private readonly List<string> ValidCategories = ["Italian", "Egyption", "Japanes", "American", "Indian"];
        public CreateResturantDtoValidator()
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
