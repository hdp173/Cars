using MyCars.Controllers.Resources;
using MyCars.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCars.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery queryObj);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}
