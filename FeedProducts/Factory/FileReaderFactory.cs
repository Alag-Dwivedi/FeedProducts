using FeedProducts.FileReader;

namespace FeedProducts.Factory
{
    public abstract class FileReaderFactory
    {
        public abstract IFileReader GetFileReader(string path);

    }
}
