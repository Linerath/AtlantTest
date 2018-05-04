using AtlantTest.Database;
using AtlantTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtlantTest.Controllers
{
    public class HomeController : Controller
    {
        private IStorekeeperRepository storekeeperRepository;

        public HomeController(IStorekeeperRepository storekeeperRepository)
        {
            this.storekeeperRepository = storekeeperRepository;
        }

        public ActionResult Index()
        {
            var s = storekeeperRepository.GetAll();
            return View(s);
        }
    }
}