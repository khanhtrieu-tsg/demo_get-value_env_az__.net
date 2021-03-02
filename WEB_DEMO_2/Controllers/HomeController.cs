using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_DEMO_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var name = "";
            var role = "";
            name = System.Configuration.ConfigurationManager.AppSettings["name"];
            role = System.Configuration.ConfigurationManager.AppSettings["role"];
            if (name == null )
            {
                name = ConfigurationManager.AppSettings["name2"];
                role = ConfigurationManager.AppSettings["role"];
                if (name == null)
                {
                    name = Environment.GetEnvironmentVariable("name");
                    role = Environment.GetEnvironmentVariable("role");
                }
            }
            ViewBag.name = name;
            ViewBag.email = role == null ? "" : role;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
        
    }
}