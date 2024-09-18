using ProductLib;

namespace ProductPricingsConsole;

class Program
{
    static void Main(string[] args)
    {
        // | ========< Task 1 >========| 
        // Create ProductsPricing Library

        //ProductCreateReq prdReq = new ProductCreateReq("P001", "Apple", Category.Food);

        //Product prd = new Product(prdReq.Code, prdReq.Name, prdReq.Category);

        //ProductResponse prdRes = new ProductResponse(prd);
        //Console.WriteLine($"Product Input, Code={prdRes.Code}, Name={prdRes.Name}, Category={prdRes.Category}");

        //Console.WriteLine($"Product Created: ID={prdRes.Id}, Code={prdRes.Code}, Name={prdRes.Name}, Category={prdRes.Category}");

        // | ========< Task 2 >========| 
        // Create a class representing a service of products

        ProductService pServices = new ProductService();
        string filePath = @"D:\RUPP\RUPP Y4\OOAD\Application\ProductPricings\products.json";
        pServices.Initailized(filePath);

        ProductCreateReq pReq = new ProductCreateReq("P003", "Coca", Category.Drink);
        string pID = pServices.Create(pReq);
        Console.WriteLine($"New Product Created With ID: {pID}");

        var allProducts = pServices.ReadAll();
        foreach (var pResponse in allProducts) 
        {
            Console.WriteLine($"ID={pResponse.Id}, Code={pResponse.Code}, Name={pResponse.Name}, Category={pResponse.Category}");
        }
        pServices.Save(filePath);
    }
}
