namespace ProductLib;

public class Product
{
    public string Id { set; get; } = Guid.NewGuid().ToString();
    public string Code { set; get; }
    public string Name { set; get; }
    public Category Category { set; get; }
    public DateTime ?Created { set; get; }
    public DateTime? LastUpdated { set; get; }
    public Product(string code, string name, Category category)
    {
        Code = code;
        Name = name;
        Category = category;
    }
}
