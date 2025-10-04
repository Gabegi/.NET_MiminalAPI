namespace MinimalAPI.Models.Requests;

public abstract class CustomerRequestBase
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
