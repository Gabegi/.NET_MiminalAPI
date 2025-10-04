using MinimalAPI.Models.Requests;

namespace MinimalAPI.Validators;

public class CreateCustomerValidator : CustomerRequestValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        // Inherit all base validation rules from CustomerRequestValidator
        // In a real app, you would add email uniqueness check with MustAsync here
    }
}
