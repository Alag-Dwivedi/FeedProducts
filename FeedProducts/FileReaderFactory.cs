namespace FeedProducts
{
    public abstract class FileReaderFactory
    {
        public abstract IFileReader GetFileReader(string path);

    }
}
