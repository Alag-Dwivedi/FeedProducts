using FeedProducts.Model;
using Newtonsoft.Json;
using System.Text;

namespace FeedProducts
{
    public class JsonFileReader : IFileReader
    {
        public void Read(string path)
        {
            using StreamReader file = new StreamReader(path);
            try
            {
                string text = file.ReadToEnd();
                var data = JsonConvert.DeserializeObject<JsonConfig>(text);
                if (data != null)
                {
                    foreach (var item in data.Products)
                    {
                        StringBuilder str = new StringBuilder();
                        str.Append($"importing: Name: {item.Title}; Categories: {string.Join(",", item.Categories.ToArray())};");
                        if (item.Twitter != null)
                        {
                            str.Append($" Twitter: {item.Twitter};");
                        }
                        Console.Write($"{str} \n");
                    }
                    Console.ReadLine();
                }
                else
                {
                    throw new ArgumentException("Parsing Error");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Problem reading file: {ex.Message}");
            }
        }
    }
}
