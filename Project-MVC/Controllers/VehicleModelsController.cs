using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Project.Service.DAL;
using Project.Service.Models;
using PagedList;

namespace Project_MVC.Controllers
{
    public class VehicleModelsController : Controller
    {
        private VehicleContext db = new VehicleContext();

        // GET: VehicleModels
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "abrv_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

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
            var models = from m in db.VehicleModel
                           select m;

            //filtering
            if (!String.IsNullOrEmpty(searchString))
            {
                models = models.Where(m => m.ModelName.Contains(searchString)
                                       || m.ModelAbbreviation.Contains(searchString));
            }

            //sorting
            switch (sortOrder)
            {
                case "name_desc":
                    models = models.OrderByDescending(m => m.ModelName);
                    break;


                case "abrv_desc":
                    models = models.OrderByDescending(m => m.ModelAbbreviation);
                    break;

                case "id_desc":
                    models = models.OrderByDescending(m => m.MakeID);
                    break;

                default:
                    models = models.OrderBy(m => m.ModelName);
                    break;
            }

            //paging
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(models.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public ActionResult Create()
        {
            //dropdown list
            ViewBag.MakeID = new SelectList(db.VehicleMake, "ID", "VehicleName");
            return View();
        }

        // POST: VehicleModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MakeID,ModelName,ModelAbbreviation")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.VehicleModel.Add(vehicleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //dropdown list
            ViewBag.MakeID = new SelectList(db.VehicleMake, "ID", "VehicleName", vehicleModel.MakeID);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MakeID,ModelName,ModelAbbreviation")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            db.VehicleModel.Remove(vehicleModel);
            db.SaveChanges();
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