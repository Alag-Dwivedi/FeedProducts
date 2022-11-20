using FeedProducts.Model;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FeedProducts.FileReader
{
    public class YamlFileReader : IFileReader
    {
        public List<ProductInventory> Read(string path)
        {
            try
            {
                var deserializer = new DeserializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build();
                var yamlData = deserializer.Deserialize<List<YamlConfig>>(File.ReadAllText(path));
                if (yamlData != null)
                {
                    var yamlInventory = new List<ProductInventory>();
                    foreach (var item in yamlData)
                    {
                        yamlInventory.Add(new ProductInventory()
                        {
                            Title = item.Name,
                            Categories = item.Tags,
                            Twitter = item.Twitter,
                        });
                    }

                    return yamlInventory;
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
