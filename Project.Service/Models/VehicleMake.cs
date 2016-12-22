using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Models
{
    public class VehicleMake
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string VehicleName { get; set; }
        public string VehicleAbbreviation { get; set; }

        public virtual ICollection<VehicleModel> VehicleModel { get; set; }
    }
}
