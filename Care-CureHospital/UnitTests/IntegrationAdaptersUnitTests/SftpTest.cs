using Backend.Service;
using Moq;
using Xunit;

namespace UnitTests.IntegrationAdaptersUnitTests
{
    public class SftpTest
    {
        [Fact]
        public void Upload_report()
        {
            var mockService = new Mock<ISftpService>();
            var file = mockService.Setup(searchResult => searchResult.UploadFile("Files\\Report.json"));
            Assert.NotNull(file);
        }

        [Fact]
        public void Upload_prescription()
        {
            var mockService = new Mock<ISftpService>();
            var file = mockService.Setup(searchResult => searchResult.UploadFile("Files\\Prescription.json"));
            Assert.NotNull(file);
        }
    }
}
