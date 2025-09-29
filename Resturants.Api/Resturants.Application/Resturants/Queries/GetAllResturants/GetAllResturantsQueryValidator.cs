using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Queries.GetAllResturants;

public class GetAllResturantsQueryValidator : AbstractValidator<GetAllResturantsQuery>
{
    private int[] allowedPageSizes = [5, 10, 15, 30];
    public GetAllResturantsQueryValidator()
    {
        RuleFor(r => r.PageNumber)
            .GreaterThanOrEqualTo(1);
        RuleFor(r => r.PageSize)
            .Must(value => allowedPageSizes.Contains(value))
            .WithMessage($"page size must be in [{string.Join(",", allowedPageSizes)}]");
    }
}
