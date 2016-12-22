using System.Collections.Generic;
using System.Data.Entity;
using Project.Service.Models;

namespace Project.Service.DAL
{
    class VehicleInitializer : DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var vehicles = new List<VehicleMake>
            {
            new VehicleMake{VehicleName="Volkswagen", VehicleAbbreviation="VW"},
            new VehicleMake{VehicleName="Mercedes", VehicleAbbreviation="Mcd"},
            };

            vehicles.ForEach(s => context.VehicleMake.Add(s));
            context.SaveChanges();

            var models = new List<VehicleModel>
            {
            new VehicleModel{ModelName="Golf 6", ModelAbbreviation="G6"},
            new VehicleModel{ModelName="Cls", ModelAbbreviation="Cls"},   
            };
            models.ForEach(m => context.VehicleModel.Add(m));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
