using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ShipController : Controller
    {
        // GET: Ship
        public ActionResult Ship()
        {
            if (Session["LogonUser"] == null)
            {
                return RedirectToAction("Login", "User", null);
            }
            List<ships> ship = new List<ships>();

            using (Model1Container container = new Model1Container())
            {
                ship = container.ships.ToList();
            }

            return View(ship);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(addShipViewModel asvm)
        {
            if (Session["LogonUser"] == null)
            {
                return RedirectToAction("Login", "User", null);
            }
            var ship = new ships();

            using (Model1Container container = new Model1Container())
            {
                ship.ship_num = asvm.ship_num;
                ship.ship_name = asvm.ship_name;

                container.ships.Add(ship);
                container.SaveChanges();
            }
            return RedirectToAction("Ship");
        }

        public ActionResult Edit(int id)
        {
            if (Session["LogonUser"] == null)
            {
                return RedirectToAction("Login", "User", null);
            }
            var ship = new ships();
            //editScheduleViewModel esvm = new editScheduleViewModel();

            using (Model1Container container = new Model1Container())
            {
                ship = container.ships.Single(dbo => dbo.Id == id);
            }

            return View(ship);
        }

        [HttpPost]
        public ActionResult Edit(ships obj)
        {
            var ship = new ships();

            using (Model1Container container = new Model1Container())
            {
                ship = container.ships.Where(dbo => dbo.Id == obj.Id).FirstOrDefault();
                ship.ship_num = obj.ship_num;
                ship.ship_name = obj.ship_name;


                container.SaveChanges();
            }
            return RedirectToAction("Ship");
        }

        public ActionResult Delete(int id)
        {
            if (Session["LogonUser"] == null)
            {
                return RedirectToAction("Login", "User", null);
            }
            var ship = new ships();

            using (Model1Container container = new Model1Container())
            {
                ship = container.ships.Single(dbo => dbo.Id == id);

                container.ships.Remove(ship);
                container.SaveChanges();
            }

            return RedirectToAction("Ship");
        }
    }
}