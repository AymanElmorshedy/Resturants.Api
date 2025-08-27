using FluentValidation;
using Resturants.Application.Resturants.Commands.UpdateResturant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Validators.Resturant
{
    public class UpdateResturantCommandValidator : AbstractValidator<UpdateResturantCommand>
    {
        public UpdateResturantCommandValidator()
        {
            RuleFor(c => c.Name)
                .Length(3, 100);
        }
    }
}
