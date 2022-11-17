namespace FeedProducts.Model
{
    public class JsonConfig
    {
        public List<Products> Products { get; set; }
    }

    public class Products
    {
        public List<string> Categories { get; set; }
        public string? Twitter { get; set; }
        public string Title { get; set; }
    }
}
