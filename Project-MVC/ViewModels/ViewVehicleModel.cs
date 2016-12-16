using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_MVC.ViewModels
{
    public class ViewVehicleModel
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