using Microsoft.AspNetCore.Http;
using MyCars.Core.Model;
using System.Threading.Tasks;

namespace MyCars.Core
{
    public interface IPhotoService
    {
        Task<Photo> UploadPhoto(Vehicle vehicle, IFormFile file, string uploadsFolderPath);
    }
}
