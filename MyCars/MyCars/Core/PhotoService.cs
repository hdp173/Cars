using Microsoft.AspNetCore.Http;
using MyCars.Core.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyCars.Core
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPhotoStorage photoStorage;

        public PhotoService(IUnitOfWork unitOfWork, IPhotoStorage photoStorage)
        {
            this.unitOfWork = unitOfWork;
            this.photoStorage = photoStorage;
        }

        public async Task<Photo> UploadPhoto(Vehicle vehicle, IFormFile file, string uploadsPhotoPath)
        {
            var fileName = await photoStorage.StorePhoto(uploadsPhotoPath, file);

            var photo = new Photo { FileName = fileName };
            vehicle.Photos.Add(photo);

            await unitOfWork.CompleteAsync();

            return photo;
        }
    }
}
