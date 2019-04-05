using System.Collections.Generic;
using System.Threading.Tasks;
using LTDemoData.Models;

namespace LTDemoService.Services
{
    public interface IPhotoService
    {
        Task<IEnumerable<Photo>> GetPhotoOptions(int albumId);
    }
}