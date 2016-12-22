using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project.Service.Models;
using Project.Service.DAL;
using PagedList;
using System.Data.Entity.Migrations;

namespace Project.Service
{
    public class VehicleService
    {
        private static VehicleService Vehicleservice;
        private readonly VehicleContext db;
        private VehicleMake vehicleMake;
        private VehicleModel vehicleModel;

        private VehicleService()
        {
            db = new VehicleContext();
        }
        public static VehicleService GetInstance()
        {
            if (Vehicleservice == null)
            {
                Vehicleservice = new VehicleService();
                return Vehicleservice;
            }
            else return Vehicleservice;
        }
        public void CreateVehicleMake()
        {

            db.VehicleMake.Add(Mapper.Map<VehicleMake>(vehicleMake));
            db.SaveChanges();
        }

        public void CreateVehicleModel()
        {
            db.VehicleModel.Add(Mapper.Map<VehicleModel>(vehicleModel));
            db.SaveChanges();
        }

     

        public void DeleteVehicleMake(int id)
        {
            VehicleMake vehicleMake = db.VehicleMake.Find(id);
            db.VehicleMake.Remove(vehicleMake);
            db.SaveChanges();
        }

        public void DeleteVehicleModel(int id)
        {
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            db.VehicleModel.Remove(vehicleModel);
            db.SaveChanges();
        }

        public void UpdateVehicleMake()
        {
            db.Set<VehicleMake>().AddOrUpdate(Mapper.Map<VehicleMake>(vehicleMake));
            db.SaveChanges();
        }

        public void UpdateVehicleModel()
        {
            db.Set<VehicleModel>().AddOrUpdate(Mapper.Map<VehicleModel>(vehicleModel));
            db.SaveChanges();
        }

    }
}
