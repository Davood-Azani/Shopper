using FluentValidation;
using Shopper.Application.Product.Dtos;

namespace Shopper.Application.Product.Queries.GetAllProducts;

public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>
{
    private readonly int[] _allowedPageSizes = [5, 10, 15, 30];
    private readonly string[] _allowedSortByColumnNames = [nameof(ProductDto.Name), nameof(ProductDto.Price)];
    public GetAllProductsQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(1);
        RuleFor(x => x.PageSize)
            .Must(x => _allowedPageSizes.Contains(x))
            .WithMessage($"PageSize must in [{string.Join(",", _allowedPageSizes)}]");

        RuleFor(x => x.SortBy)
            .Must(x => string.IsNullOrEmpty(x) || _allowedSortByColumnNames.Contains(x))
            .WithMessage($"Sort by is optional or must in [{string.Join(",", _allowedSortByColumnNames)}]");




    }
}
