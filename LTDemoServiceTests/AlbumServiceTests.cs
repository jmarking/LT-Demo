using System;
using System.Collections.Generic;
using LTDemoService.Services;
using Xunit;
using System.Linq;
using LTDemoData.Models;
using Moq;
using LTDemoData;

namespace LTDemoServiceTests
{
    public class AlbumServiceTests
    {
        [Fact]
        public void GetAlbumOptions_ShouldEqualTestAlbums()
        {
            var mockWebServiceData = new Mock<IWebServiceData>();
            mockWebServiceData.Setup(x => x.GetAlbums()).ReturnsAsync(TestAlbums());
            var albumService = new AlbumService(mockWebServiceData.Object);

            var albums = albumService.GetAlbumOptions().Result;

            Assert.Collection(albums, album1 =>
            {
                var testAlbum1 = TestAlbums().ElementAt(0);
                Assert.Equal(testAlbum1.Id, album1.Id);
                Assert.Equal(testAlbum1.Title, album1.Title);
            },
            album2 =>
            {
                var testAlbum2 = TestAlbums().ElementAt(1);
                Assert.Equal(testAlbum2.Id, album2.Id);
                Assert.Equal(testAlbum2.Title, album2.Title);
            });
        }

        private IEnumerable<Album> TestAlbums() =>
            new List<Album>
            {
                new Album{
                    Id=1,
                    Title="Testing album id 1"
                },
                new Album{
                    Id=2,
                    Title="Testing album id 2"
                }
            };
    }
}
