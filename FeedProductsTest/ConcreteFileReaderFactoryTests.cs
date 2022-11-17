using FeedProducts;

namespace FeedProductsTest
{
    public class ConcreteFileReaderFactoryTests
    {
        [Fact]
        public void GetFileReader_Should_Return_An_Instance_Of_YamlFileReader_When_Path_Contains_Yaml()
        {
            // Arrange
            var path = "capterra.yaml";
            ConcreteFileReaderFactory readerFactory = new ConcreteFileReaderFactory();

            // Act
            var res = readerFactory.GetFileReader(path);

            // Assert
            Assert.IsType<YamlFileReader>(res);
        }

        [Fact]
        public void GetFileReader_Should_Return_An_Instance_Of_jsonFileReader_When_Path_Contains_Json()
        {
            // Arrange
            var path = "softwareadvice.json";
            ConcreteFileReaderFactory readerFactory = new ConcreteFileReaderFactory();

            // Act
            var res = readerFactory.GetFileReader(path);

            // Assert
            Assert.IsType<JsonFileReader>(res);
        }

        [Fact]
        public void GetFileReader_Should_Throw_NotImplementedException_When_File_type_Does_Not_Match_Supported_Format()
        {
            // Arrange
            var path = "softwareadvice.txt";
            ConcreteFileReaderFactory readerFactory = new ConcreteFileReaderFactory();

            // Act
            var res = () => readerFactory.GetFileReader(path);

            // Assert
            Assert.Throws<NotImplementedException>(res);
        }
    }
}