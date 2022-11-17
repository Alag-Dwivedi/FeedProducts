using FeedProducts.Model;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FeedProducts
{
    public class YamlFileReader : IFileReader
    {
        public void Read(string path)
        {
            try
            {
                var deserializer = new DeserializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build();
                var yamlData = deserializer.Deserialize<List<YamlConfig>>(File.ReadAllText(path));
                if (yamlData != null)
                {
                    foreach (var item in yamlData)
                    {
                        StringBuilder str = new StringBuilder();
                        str.Append($"importing: Name: {item.Name}; Categories: {item.Tags};");
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
