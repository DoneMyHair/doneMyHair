using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoneMyHair.Controllers
{
    public class SaloonController : Controller
    {
        // GET: Saloon
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Saloon()
        {
            return View();
        }
        public ActionResult Hairdresser()
        {
            return View();
        }
        public ActionResult NewHairdresser()
        {
            return View();
        }
        public ActionResult WaitingAppointments()
        {
            return View();
        }
    }
}