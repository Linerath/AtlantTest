using AtlantTest.Entities;
using AtlantTest.Repositories;
using AtlantTest.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpPost]
        public HttpStatusCodeResult Add(Detail detail)
        {
            var a = Request.Form["creationDate"];
            if (ModelState.IsValid)
            {
                detailsService.Add(detail);

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}