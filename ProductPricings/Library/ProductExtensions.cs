namespace ProductLib;

public static class ProductExtensions
{
    // =====< By Me >=====
    //public static Product ToEntity(this ProductCreateReq req)
    //{
    //    return new Product(req.Code, req.Name, req.Category);
    //}
    //public static ProductResponse ToResponse(this Product product)
    //{
    //    return new ProductResponse(product);
    //}

    // =====< By Teacher >=====
    public static Product ToEntity(this ProductCreateReq req)
    {
        return new Product(req.Code, req.Name, req.Category);
    }
    public static ProductResponse ToResponse(this Product product)
    {
        return new ProductResponse(product);
    }
}
