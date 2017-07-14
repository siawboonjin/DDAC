using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            if (Session["LogonUser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Schedule> schedules = new List<Schedule>();

            using (Model1Container container = new Model1Container())
            {
                schedules = container.Schedules.ToList();
            }

            return View(schedules);
        }

        private void loadShipnum(List<SelectListItem> list)
        {
            List<ships> ship = new List<ships>();

            using (Model1Container container = new Model1Container())
            {
                ship = container.ships.ToList();
            }

            for (int i = 0; i < ship.Count(); i++)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = ship[i].ship_num;
                sli.Value = ship[i].ship_num.ToString();
                list.Add(sli);
            }
        }

        private void loadStatus(List<SelectListItem> list)
        {
            SelectListItem sli = new SelectListItem();
            sli.Text = "In Progress";
            sli.Value = "In Progress";
            list.Add(sli);

            sli = new SelectListItem();
            sli.Text = "Reached";
            sli.Value = "Reached";
            list.Add(sli);
        }

        public ActionResult Create()
        {
            if (Session["LogonUser"] == null)
            {
                return RedirectToAction("Login", "User", null);
            }
            addScheduleViewModel asvm = new addScheduleViewModel();
            asvm.listShipnum = new List<SelectListItem>();
            loadShipnum(asvm.listShipnum);
            asvm.listStatus = new List<SelectListItem>();
            loadStatus(asvm.listStatus);

            return View(asvm);

        }

        [HttpPost]
        public ActionResult Create(addScheduleViewModel asvm)
        {
            var schedule = new Schedule();

            using (Model1Container container = new Model1Container())
            {
                schedule.departure = asvm.departure;
                schedule.destination = asvm.destination;
                schedule.weight = asvm.weight;
                schedule.deliver_date = asvm.deliver_date;
                schedule.ship_num = asvm.ship_num;
                schedule.status = asvm.status;

                container.Schedules.Add(schedule);
                container.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (Session["LogonUser"] == null)
            {
                return RedirectToAction("Login", "User", null);
            }
            var schedule = new Schedule();
            editScheduleViewModel esvm = new editScheduleViewModel();
            esvm.listShipnum = new List<SelectListItem>();
            loadShipnum(esvm.listShipnum);
            esvm.listStatus = new List<SelectListItem>();
            loadStatus(esvm.listStatus);

            using (Model1Container container = new Model1Container())
            {
                schedule = container.Schedules.Where(a => a.Id == id).FirstOrDefault();
                esvm.deliver_date = schedule.deliver_date;
                esvm.departure = schedule.departure;
                esvm.destination = schedule.destination;
                esvm.Id = schedule.Id;
                esvm.weight = schedule.weight;

            }

            return View(esvm);
        }

        [HttpPost]
        public ActionResult Edit(Schedule obj)
        {
            var schedule = new Schedule();

            using (Model1Container container = new Model1Container())
            {
                schedule = container.Schedules.Single(a => a.Id == obj.Id);
                schedule.departure = obj.departure;
                schedule.destination = obj.destination;
                schedule.deliver_date = obj.deliver_date;
                schedule.weight = obj.weight;
                schedule.ship_num = obj.ship_num;
                schedule.status = obj.status;

                container.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            if (Session["LogonUser"] == null)
            {
                return RedirectToAction("Login", "User", null);
            }
            var schedule = new Schedule();

            using (Model1Container container = new Model1Container())
            {
                schedule = container.Schedules.Where(a => a.Id == id).FirstOrDefault();
                container.Schedules.Remove(schedule);
                container.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}