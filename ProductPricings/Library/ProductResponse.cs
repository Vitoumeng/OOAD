namespace ProductLib;

public class ProductResponse
{
    public string Id { get; set; }  
    public string Code { get; set; }  
    public string Name { get; set; }  
    public Category Category { get; set; }  

    public ProductResponse(Product product)
    {
        Id = product.Id;
        Code = product.Code;
        Name = product.Name;
        Category = product.Category;
    }
}
