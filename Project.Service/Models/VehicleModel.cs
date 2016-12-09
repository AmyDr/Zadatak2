using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Models
{
    public class VehicleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MakeID { get; set; }
        public string ModelName { get; set; }
        public string ModelAbbreviation { get; set; }

        public virtual VehicleMake VehicleMake { get; set; }
    }
}
