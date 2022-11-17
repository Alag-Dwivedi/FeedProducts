// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;



//static dynamic Read(string path)
//{
//    using (StreamReader file = new StreamReader(path))
//    {
//        try
//        {
//            string json = file.ReadToEnd();

//            var serializerSettings = new JsonSerializerSettings
//            {
//                ContractResolver = new CamelCasePropertyNamesContractResolver()
//            };

//            return JsonConvert.DeserializeObject<dynamic>(json, serializerSettings);
//        }
//        catch (Exception)
//        {
//            Console.WriteLine("Problem reading file");

//            return null;
//        }
//    }
//}
//var data = Read("../../../feed-products/softwareadvice.json");

//Console.WriteLine(data);


namespace FeedProducts
{
    public static class Program
    {

        /// <summary>
        ///   ../../../feed-products/softwareadvice.json
        ///   ../../../feed-products/capterra.yaml
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the file path:");
            var filePath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("Command can't be empty");
            }
            if(!filePath.Contains("import"))
            {
                throw new ArgumentException("Invalid Input");
            }
            FileReaderFactory fileReader = new ConcreteFileReaderFactory();
            var path = filePath.Split(" ");
            IFileReader reader = fileReader.GetFileReader(path[2]);
            var rootPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf("FeedProducts")) + path[2];
            reader.Read(rootPath);
        }


    }
}
