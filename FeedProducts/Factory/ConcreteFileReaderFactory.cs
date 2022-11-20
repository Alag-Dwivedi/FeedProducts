using FeedProducts.FileReader;
namespace FeedProducts.Factory
{
    public class ConcreteFileReaderFactory : FileReaderFactory
    {
        /// <summary>
        /// Returns an instance of respective file reader depending on input file type
        /// </summary>
        /// <param name="path"></param>
        /// <returns>YamlFileReader</returns>
        /// <returns>JsonFileReader</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IFileReader GetFileReader(string path)
        {
            if (path != null && path.Contains(".yaml"))
            {
                return new YamlFileReader();
            }
            else if (path != null && path.Contains(".json"))
            {
                return new JsonFileReader();
            }

            throw new NotImplementedException();
        }
    }
}
