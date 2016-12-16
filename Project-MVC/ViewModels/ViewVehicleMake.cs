using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_MVC.ViewModels
{
    public class ViewVehicleMake
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string VehicleName { get; set; }
        public string VehicleAbbreviation { get; set; }

        public virtual ICollection<VehicleModel> VehicleModel { get; set; }
    }
}