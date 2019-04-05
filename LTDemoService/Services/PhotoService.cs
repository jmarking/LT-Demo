using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTDemoData;
using LTDemoData.Models;

namespace LTDemoService.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IWebServiceData _webServiceData;

        public PhotoService(IWebServiceData webServiceData)
        {
            _webServiceData = webServiceData;
        }

        public async Task<IEnumerable<Photo>> GetPhotoOptions(int albumId) => await _webServiceData.GetPhotos(albumId);
    }
}