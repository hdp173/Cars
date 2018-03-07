using Microsoft.EntityFrameworkCore;
using MyCars.Core;
using MyCars.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCars.Persistence
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly MyCarsDbContext context;
        public PhotoRepository(MyCarsDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Photo>> GetPhotos(int vehicleId)
        {
            return await context.Photos
              .Where(p => p.VehicleId == vehicleId)
              .ToListAsync();
        }
    }
}