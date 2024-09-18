using ProductLib;

namespace ProductPricingsConsole;

class Program
{
    static void Main(string[] args)
    {
        ProductCreateReq prdReq = new ProductCreateReq("P001", "Apple", Category.Food);

        Product prd = new Product(prdReq.Code, prdReq.Name, prdReq.Category);

        ProductResponse prdRes = new ProductResponse(prd);
        Console.WriteLine($"Product Input, Code={prdRes.Code}, Name={prdRes.Name}, Category={prdRes.Category}");

        Console.WriteLine($"Product Created: ID={prdRes.Id}, Code={prdRes.Code}, Name={prdRes.Name}, Category={prdRes.Category}");
    }
}
