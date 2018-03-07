using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyCars.Controllers.Resources;
using MyCars.Core;
using MyCars.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCars.Controllers
{
    [Route("/api/vehicles/{vehicleId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IPhotoRepository photoRepository;
        private readonly IMapper mapper;
        private readonly IPhotoService photoService;
        private readonly PhotoSettings photoSettings;

        public PhotosController(
            IHostingEnvironment host, 
            IVehicleRepository vehicleRepository, 
            IPhotoRepository photoRepository, 
            IMapper mapper, 
            IOptionsSnapshot<PhotoSettings> options,
            IPhotoService photoService)
        {
            this.photoSettings = options.Value;
            this.host = host;
            this.vehicleRepository = vehicleRepository;
            this.photoRepository = photoRepository;
            this.mapper = mapper;
            this.photoService = photoService;
        }

        [HttpGet]
        public async Task<IEnumerable<PhotoResource>> GetPhotos(int vehicleId)
        {
            var photos = await photoRepository.GetPhotos(vehicleId);

            return mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoResource>>(photos);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int vehicleId, IFormFile file)
        {
            var vehicle = await vehicleRepository.GetVehicle(vehicleId, false);

            if (vehicle == null)
                return NotFound();

            if (file == null) return BadRequest("Null file");
            if (file.Length == 0) return BadRequest("Empty file");
            if (file.Length > photoSettings.MaxBytes) return BadRequest("Max size excided");
            if (!photoSettings.IsSupported(file.FileName)) return BadRequest("Wrong file format");

            var uploadFolderPath = Path.Combine(host.WebRootPath, "uploads");

            var photo = await photoService.UploadPhoto(vehicle, file, uploadFolderPath);

            return Ok(mapper.Map<Photo, PhotoResource>(photo));
        }
    }
}
