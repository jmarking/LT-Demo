using System.Collections.Generic;
using System.Linq;
using LTDemoData;
using LTDemoData.Models;
using LTDemoService.Services;
using Moq;
using Xunit;

namespace LTDemoServiceTests
{
    public class PhotoServiceTests
    {
        [Fact]
        public void GetPhotoOptions_ShouldEqualTestPhotos()
        {
            var mockWebServiceData = new Mock<IWebServiceData>();
            mockWebServiceData.Setup(x => x.GetPhotos(It.IsAny<int>())).ReturnsAsync(TestPhotos());
            var photoService = new PhotoService(mockWebServiceData.Object);

            var photos = photoService.GetPhotoOptions(4).Result;

            Assert.Collection(photos, photo1 =>
            {
                var testPhoto1 = TestPhotos().ElementAt(0);
                Assert.Equal(testPhoto1.Id, photo1.Id);
                Assert.Equal(testPhoto1.Title, photo1.Title);
            },
            photo2 =>
            {
                var testPhoto2 = TestPhotos().ElementAt(1);
                Assert.Equal(testPhoto2.Id, photo2.Id);
                Assert.Equal(testPhoto2.Title, photo2.Title);
            });
        }

        private IEnumerable<Photo> TestPhotos() =>
            new List<Photo>
            {
                new Photo{
                    Id=1,
                    Title="Testing photo id 1"
                },
                new Photo{
                    Id=2,
                    Title="Testing photo id 2"
                }
            };
    }
}