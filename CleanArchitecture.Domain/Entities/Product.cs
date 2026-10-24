namespace ProductCatalog.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    private Product() { }

    public Product(string name, decimal price)
    {
        Id = Guid.NewGuid();
        SetName(name);
        SetPrice(price);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.", nameof(name));

        Name = name;
    }

    public void SetPrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.", nameof(price));

        Price = price;
    }
}