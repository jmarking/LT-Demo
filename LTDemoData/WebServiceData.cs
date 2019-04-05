using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LTDemoData.Models;
using Newtonsoft.Json;

namespace LTDemoData
{
    public class WebServiceData : IWebServiceData
    {
        public async Task<IEnumerable<Album>> GetAlbums()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/albums");
                var albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(response);
                return albums;
            }
        }
        public async Task<IEnumerable<Photo>> GetPhotos(int albumId)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync($"https://jsonplaceholder.typicode.com/photos?albumId={albumId}");
                var photos = JsonConvert.DeserializeObject<IEnumerable<Photo>>(response);
                return photos;
            }
        }
    }
}
