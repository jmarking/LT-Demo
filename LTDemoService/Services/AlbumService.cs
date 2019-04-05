using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTDemoData;
using LTDemoData.Models;

namespace LTDemoService.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IWebServiceData _webServiceData;

        public AlbumService(IWebServiceData webServiceData)
        {
            _webServiceData = webServiceData;
        }

        public async Task<IEnumerable<Album>> GetAlbumOptions() => await _webServiceData.GetAlbums();
    }
}
