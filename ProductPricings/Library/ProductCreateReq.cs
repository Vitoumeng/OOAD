namespace ProductLib
{
    public class ProductCreateReq
    {
        public string Code { get; set; }  
        public string Name { get; set; }  
        public Category Category { get; set; }
        public ProductCreateReq(string code, string name, Category category) 
        {
            Code = code;
            Name = name;
            Category = category;
        }
    }
}
