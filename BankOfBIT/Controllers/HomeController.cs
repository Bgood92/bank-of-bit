using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankOfBIT.Controllers
{
    public class HomeController : Controller
    {
        //Modified ViewBag.Message in the following:
        //Index() - ViewBag.Message = "Online Banking for the Bank of BIT Clients."
        //About() - ViewBag.Message = "Bank of BIT Application."
        //Contact() - ViewBag.Message = "Find our Contact Information here."

        public ActionResult Index()
        {
            ViewBag.Message = "Online Banking for the Bank of BIT Clients.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bank of BIT Application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Find our Contact Information here.";

            return View();
        }
    }
}
