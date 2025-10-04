namespace MinimalAPI.Models.Requests;

public abstract class ProductRequestBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
