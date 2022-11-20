using FeedProducts.Model;

namespace FeedProducts.FileReader
{
    public interface IFileReader
    {
        List<ProductInventory> Read(string path);
    }
}
