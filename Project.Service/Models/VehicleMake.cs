using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Models
{
    public  class VehicleMake
    {
        public int ID { get; set; }
        public string VehicleName { get; set; }
        public string VehicleAbbreviation { get; set; }

        public virtual ICollection<VehicleModel> VehicleModel { get; set; }
    }
}
