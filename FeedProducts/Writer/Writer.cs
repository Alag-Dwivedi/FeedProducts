using FeedProducts.Model;
using System.Text;

namespace FeedProducts.Writer
{
    public static class Writer
    {
        public static void Write(this IList<ProductInventory> inventory)
        {

            foreach (var item in inventory)
            {
                StringBuilder str = new StringBuilder();
                str.Append($"importing: Name: {item.Title}; Categories: {item.Categories};");
                if (item.Twitter != null)
                {
                    str.Append($" Twitter: {item.Twitter};");
                }
                Console.Write($"{str} \n");
            }
            Console.ReadLine();
        }
    }
}
