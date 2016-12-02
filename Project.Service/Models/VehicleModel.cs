﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Models
{
    public class VehicleModel
    {
        public int ID { get; set; }
        public int MakeID { get; set; }
        public string ModelName { get; set; }
        public string ModelAbbreviation { get; set; }

        public virtual VehicleMake VehicleMake { get; set; }
    }
}