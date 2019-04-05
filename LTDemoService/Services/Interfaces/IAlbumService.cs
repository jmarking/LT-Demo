using System.Collections.Generic;
using System.Threading.Tasks;
using LTDemoData.Models;

namespace LTDemoService.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAlbumOptions();
    }
}