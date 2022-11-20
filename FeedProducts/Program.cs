using FeedProducts.Factory;
using FeedProducts.FileReader;
using FeedProducts.Writer;

namespace FeedProducts
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Constants.Constants.EnterFilePath);
            var filePath = Console.ReadLine();
            ValidateFilePath(filePath);
            FileReaderFactory fileReader = new ConcreteFileReaderFactory();
            var path = filePath.Split(" ");
            IFileReader reader = fileReader.GetFileReader(path[2]);
            var rootPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf(Constants.Constants.FeedProducts)) + path[2];
            var inventory = reader.Read(rootPath);
            inventory.Write();
        }

        static void ValidateFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(Constants.Constants.EmptyPath);
            }
            if (!filePath.Trim().ToLower().Contains(Constants.Constants.Import))
            {
                throw new ArgumentException(Constants.Constants.InvalidCommand);
            }
            if(filePath.Split(" ").Length < 3)
            {
                throw new ArgumentException(Constants.Constants.InvalidCommand);
            }
        }
    }
}
