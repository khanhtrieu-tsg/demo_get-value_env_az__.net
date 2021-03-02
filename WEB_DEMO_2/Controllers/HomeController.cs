using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_DEMO_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var name = "";
            //var role = "";
            //name = System.Configuration.ConfigurationManager.AppSettings["name"];

            var name = "";
            var email = "";

            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"];
            string queryString = "select  username,email from dbo.auths_user where id =2";
            using (var connection = new SqlConnection(connectionString.ConnectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine(String.Format("{0}", reader[0]));
                    name = reader[0].ToString();
                    email = reader[1].ToString();
                    break;
                }
            }

            //role = System.Configuration.ConfigurationManager.AppSettings["role"];
            //if (name == null )
            //{
            //    name = ConfigurationManager.AppSettings["name2"];
            //    role = ConfigurationManager.AppSettings["role"];
            //    if (name == null)
            //    {
            //        name = Environment.GetEnvironmentVariable("name");
            //        role = Environment.GetEnvironmentVariable("role");
            //    }
            //}
            ViewBag.name = name;
            ViewBag.email = email;
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