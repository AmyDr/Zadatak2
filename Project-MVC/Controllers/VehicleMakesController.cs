using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Service;
using Project.Service.DAL;
using Project.Service.Models;
using PagedList;

namespace Project_MVC.Controllers
{
    public class VehicleMakesController : Controller
    {
        private VehicleContext db = new VehicleContext();
        private VehicleService vehicleService;
        public VehicleMakesController()
        {
            this.vehicleService = VehicleService.GetInstance();
        }

        // GET: VehicleMakes
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "abrv_desc" : "";

            //paging
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //sorting
            var vehicles = from v in db.VehicleMake
                           select v;




            //filtering
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(v => v.VehicleName.Contains(searchString)
                                       || v.VehicleAbbreviation.Contains(searchString));
            }

            //sorting
            switch (sortOrder)
            {
                case "name_desc":
                    vehicles = vehicles.OrderByDescending(v => v.VehicleName);
                    break;


                case "abrv_desc":
                    vehicles = vehicles.OrderByDescending(v => v.VehicleAbbreviation);
                    break;

                default:
                    vehicles = vehicles.OrderBy(v => v.VehicleName);
                    break;
            }

            //paging
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(vehicles.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleMakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = vehicleService.FindVehicleMaker(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VehicleName,VehicleAbbreviation")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                vehicleService.CreateVehicleMake(vehicleMake);
                return RedirectToAction("Index");
            }

            return View(vehicleMake);
        }

        // GET: VehicleMakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VehicleMake vehicleMake = vehicleService.FindVehicleMaker(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VehicleName,VehicleAbbreviation")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                vehicleService.UpdateVehicleMake(vehicleMake);
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = vehicleService.FindVehicleMaker(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicleService.DeleteVehicleMake(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}