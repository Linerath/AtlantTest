using AtlantTest.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtlantTest.Controllers
{
    public class HomeController : Controller
    {
        private EFDbContext context = new EFDbContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}