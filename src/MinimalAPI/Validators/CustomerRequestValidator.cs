using FluentValidation;
using MinimalAPI.Models.Requests;

namespace MinimalAPI.Validators;

public abstract class CustomerRequestValidator<T> : AbstractValidator<T> where T : CustomerRequestBase
{
    protected CustomerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Customer name is required")
            .MaximumLength(100).WithMessage("Customer name must not exceed 100 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format")
            .MaximumLength(255).WithMessage("Email must not exceed 255 characters");
    }
}
