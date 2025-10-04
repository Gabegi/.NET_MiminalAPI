using FluentValidation;
using MinimalAPI.Models.Requests;

namespace MinimalAPI.Validators;

public class UpdateCustomerValidator : CustomerRequestValidator<UpdateCustomerRequest>
{
    public UpdateCustomerValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Customer ID must be greater than 0");
    }
}
