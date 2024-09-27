using System.Text.Json;
namespace ProductLib;

public class ProductService
{
    // =====< By Me >=====
    //private List<Product> products = new List<Product>();

    //public void Initailized(string filePath)
    //{
    //    if (File.Exists(filePath))
    //    {
    //        string jsonData = File.ReadAllText(filePath);
    //        products = JsonSerializer.Deserialize<List<Product>>(jsonData) ?? new List<Product>();
    //    }
    //    else
    //    {
    //        products.Add(new Product("P001", "Apple", Category.Food));
    //        products.Add(new Product("P002", "Jean", Category.Cloth));
    //        Save(filePath);
    //    }
    //}
    //public string Create(ProductCreateReq req)
    //{
    //    Product newProduct = req.ToEntity();
    //    products.Add(newProduct);
    //    return newProduct.Id;
    //}
    //public ProductResponse[] ReadAll()
    //{
    //    return products.Select(p => p.ToResponse()).ToArray();
    //}
    //public ProductResponse? Read(string id)
    //{
    //    Product? product = products.FirstOrDefault(p => p.Id == id);
    //    return product?.ToResponse();
    //}
    //public void Save(string filePath)
    //{
    //    string jsonData = JsonSerializer.Serialize(products);
    //    string directory = Path.GetDirectoryName(filePath);
    //    if (!Directory.Exists(directory))
    //    {
    //        Directory.CreateDirectory(directory);
    //    }
    //    File.WriteAllText(filePath, jsonData); 
    //}

    // =====< By Teacher >=====
    public static string DataFile { get; set; } = "products.txt";

    private List<Product> _store = new List<Product>();

    private void Save()
    {
        string jsonData = JsonSerializer.Serialize(_store);
    }
    public string[] Initialize()
    {
        if (File.Exists(DataFile))
        {
            string jsonData = File.ReadAllText(DataFile);
            _store = JsonSerializer.Deserialize<List<Product>>(jsonData) ?? new List<Product>();
        }
        else
        {
            _store.Add(new Product("P001", "Apple", Category.Food));
            _store.Add(new Product("P002", "Shirt", Category.Cloth));
            Save();
        }
        return _store.Select(p => p.Id).ToArray();
    }
    public ProductResponse[] ReadAll()
    {
        return _store.Select(p => p.ToResponse()).ToArray();
    }
    public ProductResponse? ReadAll(string key)
    {
        var product = _store.FirstOrDefault(p => p.Id == key || p.Code == key);
        return product?.ToResponse();
    }
    public string? Create(ProductCreateReq req)
    {
        if(_store.Any(p => p.Code == req.Code)) return null;
        Product newProduct = req.ToEntity();
        _store.Add(newProduct);
        Save();
        return newProduct.Id;
    }
}
