using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Project.Service.Models;

namespace Project.Service.DAL
{
    class VehicleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var vehicles = new List<VehicleMake>
            {
            new VehicleMake{ID=123, VehicleName="Volkswagen", VehicleAbbreviation="VW"},
            new VehicleMake{ID=863, VehicleName="Mercedes", VehicleAbbreviation="Mcd"},
            };

            vehicles.ForEach(s => context.VehicleMake.Add(s));
            context.SaveChanges();

            var models = new List<VehicleModel>
            {
            new VehicleModel{ID=1234,MakeID=123, ModelName="Golf 6", ModelAbbreviation="G6"},
            new VehicleModel{ID=8634,MakeID=863, ModelName="Cls", ModelAbbreviation="Cls"},   
            };
            models.ForEach(m => context.VehicleModel.Add(m));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
