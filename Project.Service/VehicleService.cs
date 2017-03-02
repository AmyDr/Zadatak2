using AutoMapper;
using Project.Service;
using Project.Service.Models;
using Project.Service.DAL;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Linq;

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
        //view index 
        public VehicleMake FindVehicleMaker(int? id)
        {
            return Mapper.Map<VehicleMake, VehicleMake>(db.VehicleMake.Find(id));
        }

        public VehicleModel FindVehicleModel(int? id)
        {
            return Mapper.Map<VehicleModel, VehicleModel>(db.VehicleModel.Find(id));
        }
        public object SearchVehicleModel()
        {
            var models = db.VehicleModel;
            return models;
        }

        // create 
        public void CreateVehicleMake(VehicleMake vehicleMake)
        {

            db.VehicleMake.Add(Mapper.Map<VehicleMake>(vehicleMake));
            db.SaveChanges();
        }

        public void CreateVehicleModel(VehicleModel vehicleModel)
        {
            db.VehicleModel.Add(Mapper.Map<VehicleModel>(vehicleModel));
            db.SaveChanges();
        }

     
        // delete 
        public void DeleteVehicleMake(int id)
        {
            VehicleMake vehicleMake = db.VehicleMake.Find(id);
            db.VehicleMake.Remove(vehicleMake);
            db.SaveChanges();
        }

        public void DeleteVehicleModel(int? id)
        {
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            db.VehicleModel.Remove(vehicleModel);
            db.SaveChanges();
        }
        // update 
        public void UpdateVehicleMake(VehicleMake vehicleMake)
        {
            db.Set<VehicleMake>().AddOrUpdate(Mapper.Map<VehicleMake>(vehicleMake));
            db.SaveChanges();
        }

        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            db.Set<VehicleModel>().AddOrUpdate(Mapper.Map<VehicleModel>(vehicleModel));
            db.SaveChanges();
        }

        public List<VehicleMake> GetAllVehicleMake()
        {
            List<VehicleMake> vehicleMakeList = db.VehicleMake.ToList();
            return vehicleMakeList;
        }

    }
}
