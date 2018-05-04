using AtlantTest.Database;
using AtlantTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtlantTest.Controllers
{
    public class StorekeepersController : Controller
    {
        private IStorekeeperRepository storekeeperRepository;

        public StorekeepersController(IStorekeeperRepository storekeeperRepository)
        {
            this.storekeeperRepository = storekeeperRepository;
        }

        public ActionResult All()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            return Json(storekeeperRepository.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}