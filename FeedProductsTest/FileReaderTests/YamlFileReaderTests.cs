using FeedProducts.FileReader;

namespace FeedProductsTest.FileReaderTests
{
    public class YamlFileReaderTests
    {
        [Fact]
        public void Read_Should_Not_Throw_An_Exception_When_File_Path_Is_Correct()
        {
            // Arrange
            YamlFileReader reader = new YamlFileReader();

            var path = $"{AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf("FeedProducts"))}/feed-products/capterra.yaml";

            // Act
            var fileData = reader.Read(path);

            // Assert
            Assert.NotNull(fileData);
        }

        [Fact]
        public void Read_Should_Not_Throw_An_Exception_When_File_Path_Is_InCorrect()
        {
            // Arrange
            JsonFileReader reader = new JsonFileReader();
            var path = "capterra.yaml";

            // Act and Assert
            Assert.Throws<FileNotFoundException>(() => reader.Read(path));
        }
    }
}
