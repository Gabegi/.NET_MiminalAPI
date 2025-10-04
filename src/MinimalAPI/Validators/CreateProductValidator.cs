using MinimalAPI.Models.Requests;

namespace MinimalAPI.Validators;

public class CreateProductValidator : ProductRequestValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        // Inherit all base validation rules from ProductRequestValidator
    }
}
