using AtlantTest.Database;
using AtlantTest.Repositories;
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
        private IDetailRepository detailRepository;

        public HomeController(IStorekeeperRepository storekeeperRepository, IDetailRepository detailRepository)
        {
            this.storekeeperRepository = storekeeperRepository;
            this.detailRepository = detailRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStorekeepers()
        {
            return Json(storekeeperRepository.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetails()
        {
            return Json(detailRepository.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}