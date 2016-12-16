using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Project.Service.Models;
using Project_MVC.ViewModels;

namespace Project_MVC.App_Start
{
    public class AppStartMappingConfiguration : Profile
    {
        public static void config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VehicleMake, ViewVehicleMake>().ReverseMap();
                cfg.CreateMap<VehicleModel, ViewVehicleModel>().ReverseMap();
            });
        }
    }
}