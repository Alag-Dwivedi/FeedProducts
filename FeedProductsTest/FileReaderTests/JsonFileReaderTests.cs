using FeedProducts.FileReader;

namespace FeedProductsTest.FileReaderTests
{
    public class JsonFileReaderTests
    {
        [Fact]
        public void Read_Should_Not_Throw_An_Exception_When_File_Path_Is_Correct()
        {
            // Arrange
            JsonFileReader reader = new JsonFileReader();

            var path = $"{AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf("FeedProducts"))}/feed-products/softwareadvice.json";

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
            var path = "softwareadvie.json";

            // Act and Assert
            Assert.Throws<FileNotFoundException>(() => reader.Read(path));
        }
    }
}
