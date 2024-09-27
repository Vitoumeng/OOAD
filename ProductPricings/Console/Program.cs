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

        // =====< By Me >=====
        //ProductService pServices = new ProductService();
        //string filePath = @"D:\RUPP\RUPP Y4\OOAD\Application\ProductPricings\products.json";
        //pServices.Initailized(filePath);
        //ProductCreateReq pReq = new ProductCreateReq("P003", "Coca", Category.Drink);
        //string pID = pServices.Create(pReq);
        //Console.WriteLine($"New Product Created With ID: {pID}");
        //var allProducts = pServices.ReadAll();
        //foreach (var pResponse in allProducts) 
        //{
        //    Console.WriteLine($"ID={pResponse.Id}, Code={pResponse.Code}, Name={pResponse.Name}, Category={pResponse.Category}");
        //}
        //pServices.Save(filePath);

        // =====< By Teacher >=====
        ProductService.DataFile = "products.txt";
        ProductService service = new ProductService();

        service.Initialize();

        Console.WriteLine("\nGetting All Product...");
        var responses= service.ReadAll();
        Show(responses.ToList());
        Pause();

        string key = "3aad99e1-5970-470f-81ef-dabe4e0fb0ff P001";
        Console.WriteLine($"\nGetting a product with id: {key}");
        var found = service.ReadAll(key);
        if (found == null)
        {
            Console.WriteLine("Not Found!!!");
        }
        else
        {
            Console.WriteLine("Found Product!!!");
            Show(found);
        }
        Pause();

        Console.WriteLine("\nProvide a request to create a product:");
        var req = new ProductCreateReq();
        Console.Write("Code: ");
        req.Code = Console.ReadLine() ?? "";
        Console.Write("Name: ");
        req.Name = Console.ReadLine() ?? "";
        var categories = Enum.GetValues(typeof(Category))
                     .Cast<Category>()
                     .Where(x => x != Category.None)
                     .ToList();

        var availableCategories = string.Join("/", categories);
        Console.WriteLine($"Available categories: {availableCategories}");

        Console.Write("Category: ");
        var inputCategory = Console.ReadLine() ?? "";

        if (Enum.TryParse(inputCategory, true, out Category parsedCategory) && categories.Contains(parsedCategory))
        {
            req.Category = parsedCategory;
        }
        else
        {
            Console.WriteLine("Invalid category. Defaulting to None.");
            req.Category = Category.None;
        }

        Console.WriteLine("\nRequest to create a new product...");
        string? id = service.Create(req);
        if (id == null)
        {
            Console.WriteLine(">Failed to create a new product");
        }
        else
        {
            Console.WriteLine($">Successfully created a product id, {id}");
            responses = service.ReadAll();
            Show(responses.ToList());
        }
        Pause();

    }
    static void Show(ProductResponse response)
    {
        var indent = new string(' ', 2);
        Console.WriteLine($"{indent}+{"id",-12}:{response.Id}");
        Console.WriteLine($"{indent}+{"code",-12}:{response.Code}");
        Console.WriteLine($"{indent}+{"name",-12}:{response.Name}");
        Console.WriteLine($"{indent}+{"category",-12}:{response.Category}");
    }
    static void Show(List<ProductResponse> responses)
    {
        var line = new string('-', 91);
        Console.WriteLine($"{"Id",-36} {"Code",-12} {"Name",-30} {"Category",-10}");
        Console.WriteLine(line);
        responses.ForEach(x =>
            Console.WriteLine($"{x.Id,-36} {x.Code,-12} {x.Name,-30} {x.Category,-10}")
        );
        Console.WriteLine(line);
    }
    static void Pause()
    {
        Console.WriteLine("Press any key");
        Console.ReadKey();
        Console.WriteLine();
    }

}