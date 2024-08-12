using FluentValidation;

namespace Shopper.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100)
            .WithMessage("Name must be between 3 and 100 characters");

        RuleFor(dto => dto.Description)
            .Length(3, 200)
            .WithMessage("Name must be between 3 and 200 characters");

       

        RuleFor(dto => dto.Price)
          
           .GreaterThan(0).WithMessage("Price must be greater than 0")
           .PrecisionScale(18, 2, true).WithMessage("Price must have a maximum of 2 decimal places and a maximum of 18 digits");
    }
}
