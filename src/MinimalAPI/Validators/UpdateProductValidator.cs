using FluentValidation;
using MinimalAPI.Models.Requests;

namespace MinimalAPI.Validators;

public class UpdateProductValidator : ProductRequestValidator<UpdateProductRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product ID must be greater than 0");
    }
}
