using FluentValidation;
using Resturants.Application.Dishes.Commands.CreateDish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Validators.Dish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(d=>d.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a non negative number");
            RuleFor(d => d.KiloCalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a non negative number");
        }
    }
}
