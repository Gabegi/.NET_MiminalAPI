using MinimalAPI.Filters;

namespace MinimalAPI.Extensions;

public static class EndpointExtensions
{
    public static RouteHandlerBuilder WithValidation<T>(this RouteHandlerBuilder builder) where T : class
    {
        return builder.AddEndpointFilter<ValidationFilter<T>>();
    }
}
