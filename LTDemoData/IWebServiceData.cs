using System.Collections.Generic;
using System.Threading.Tasks;
using LTDemoData.Models;

namespace LTDemoData
{
    public interface IWebServiceData
    {
        Task<IEnumerable<Album>> GetAlbums();
        Task<IEnumerable<Photo>> GetPhotos(int albumId);
    }
}