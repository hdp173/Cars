using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyCars.Controllers.Resources
{

    public class SaveVehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }        
        public bool IsOwned { get; set; }
        public ContactResource Contact { get; set; }
        public decimal? Price { get; set; }        
        public ICollection<int> Features { get; set; }        

        public SaveVehicleResource()
        {
            Features = new Collection<int>();            
        }
    }
}
