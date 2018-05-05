using AtlantTest.Repositories;
using AtlantTest.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtlantTest.Controllers
{
    public class DetailsController : Controller
    {
        private IDetailsService detailsService;

        public DetailsController(IDetailsService detailsService)
        {
            this.detailsService = detailsService;   
        }

        public ActionResult All()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            var details = detailsService.GetAllDetailsData();
            return Json(JsonConvert.SerializeObject(details), JsonRequestBehavior.AllowGet);
        }
    }
}