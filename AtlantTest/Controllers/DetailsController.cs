using AtlantTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtlantTest.Controllers
{
    public class DetailsController : Controller
    {
        private IDetailRepository detailRepository;

        public DetailsController(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }

        public ActionResult All()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            var details = detailRepository.GetAll();
            return Json(details, JsonRequestBehavior.AllowGet);
        }
    }
}