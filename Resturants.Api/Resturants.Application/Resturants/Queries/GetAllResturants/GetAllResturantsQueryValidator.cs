using FluentValidation;
using Resturants.Application.Resturants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Queries.GetAllResturants;

public class GetAllResturantsQueryValidator : AbstractValidator<GetAllResturantsQuery>
{
    private int[] allowedPageSizes = [5, 10, 15, 30];
    private string[] allowedSortBy = [nameof(ResturantDto.Name),
    nameof(ResturantDto.Description)
        ,nameof(ResturantDto.Category)];
    public GetAllResturantsQueryValidator()
    {
        RuleFor(r => r.PageNumber)
            .GreaterThanOrEqualTo(1);
        RuleFor(r => r.PageSize)
            .Must(value => allowedPageSizes.Contains(value))
            .WithMessage($"page size must be in [{string.Join(",", allowedPageSizes)}]");
        RuleFor(r => r.SortBy)
            .Must(value => allowedSortBy.Contains(value))
            .When(q => q.SortBy is not null)
            .WithMessage($"sort by must be in [{string.Join(",", allowedSortBy)}]");


    }
}
