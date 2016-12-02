using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Service.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Project.Service.DAL
{   
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("name=VehiclesDBEntities1")
        {
        }
        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
}
