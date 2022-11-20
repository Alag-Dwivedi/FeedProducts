using FeedProducts.Model;
using Newtonsoft.Json;


namespace FeedProducts.FileReader
{
    public class JsonFileReader : IFileReader
    {
        public List<ProductInventory> Read(string path)
        {
            using StreamReader file = new StreamReader(path);
            try
            {
                string text = file.ReadToEnd();
                var data = JsonConvert.DeserializeObject<JsonConfig>(text);
                if (data != null)
                {
                    var jsonInventory = new List<ProductInventory>();
                    foreach (var item in data.Products)
                    {
                        jsonInventory.Add(new ProductInventory()
                        {
                            Title = item.Title,
                            Categories = string.Join(",", item.Categories.ToArray()),
                            Twitter = item.Twitter,
                        });
                    }
                    return jsonInventory;
                }
                else
                {
                    throw new ArgumentException(Constants.Constants.ParsingError);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Constants.Constants.ProblemReadingFile}, {ex.Message}");
                throw;
            }
        }
    }
}
