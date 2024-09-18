using System.Text.Json;
namespace ProductLib;

public class ProductService
{
    private List<Product> products = new List<Product>();

    public void Initailized(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            products = JsonSerializer.Deserialize<List<Product>>(jsonData) ?? new List<Product>();
        }
        else
        {
            products.Add(new Product("P001", "Apple", Category.Food));
            products.Add(new Product("P002", "Jean", Category.Cloth));
            Save(filePath);
        }
    }
    public string Create(ProductCreateReq req)
    {
        Product newProduct = req.ToEntity();
        products.Add(newProduct);
        return newProduct.Id;
    }
    public ProductResponse[] ReadAll()
    {
        return products.Select(p => p.ToResponse()).ToArray();
    }
    public ProductResponse? Read(string id)
    {
        Product? product = products.FirstOrDefault(p => p.Id == id);
        return product?.ToResponse();
    }
    public void Save(string filePath)
    {
        string jsonData = JsonSerializer.Serialize(products);
        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        File.WriteAllText(filePath, jsonData); 
    }
}
