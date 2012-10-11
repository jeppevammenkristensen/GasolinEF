using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenzinStationApp.Commands;
using BenzinStationApp.Models;
using BenzinStationApp.Extensions;

namespace BenzinStationApp.Controllers
{
    public class PetrolStationController : Controller
    {
        private GasolinContext db = new GasolinContext();

        //
        // GET: /PetrolStation/

        public ActionResult Index()
        {
            return View(db.PetrolStations.ToList());
        }

        //
        // GET: /PetrolStation/Details/5

        public ActionResult Details(int id = 0)
        {
            PetrolStation petrolstation = db.PetrolStations.Find(id);
            if (petrolstation == null)
            {
                return HttpNotFound();
            }
            return View(petrolstation);
        }

        //
        // GET: /PetrolStation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PetrolStation/Create

        [HttpPost]
        public ActionResult Create(PetrolStation petrolstation)
        {
            if (ModelState.IsValid)
            {
                db.PetrolStations.Add(petrolstation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(petrolstation);
        }

        //
        // GET: /PetrolStation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PetrolStation petrolstation = db.PetrolStations.Find(id);
            if (petrolstation == null)
            {
                return HttpNotFound();
            }
            return View(petrolstation);
        }

        //
        // POST: /PetrolStation/Edit/5

        [HttpPost]
        public ActionResult Edit(PetrolStation petrolstation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petrolstation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(petrolstation);
        }

        //
        // GET: /PetrolStation/Delete/5
        public ActionResult Delete(int id = 0)
        {
            PetrolStation petrolstation = db.PetrolStations.Find(id);
            if (petrolstation == null)
            {
                return HttpNotFound();
            }
            return View(petrolstation);
        }

        public ActionResult AddPrice(int id)
        {
            var result = db.PetrolStations.Find(id);
            if (result == null)
                return HttpNotFound();

            ViewBag.StationId = id;
            return View(new AddPetrolPriceCommand{PetrolStationId = id});
        }

        [HttpPost]
        public ActionResult AddPrice(AddPetrolPriceCommand petrolPrice)
        {
            if (ModelState.IsValid)
            {
                PetrolStation petrolstation = db.PetrolStations.Find(petrolPrice.PetrolStationId);
                if (petrolstation == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    var price = new PetrolPrice();
                    petrolPrice.TransferTo(price);
                    price.StartTime = DateTime.Now;
                    petrolstation.Prices.Add(price);
                    db.SaveChanges();
                    return RedirectToAction("Details", new {id = petrolPrice.PetrolStationId});
                }
            }

            return View(petrolPrice);


        }

        //
        // POST: /PetrolStation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PetrolStation petrolstation = db.PetrolStations.Find(id);
            db.PetrolStations.Remove(petrolstation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}