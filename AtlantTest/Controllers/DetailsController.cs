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
            var detailsData = detailsService.GetAllDetailsData();
            return Json(JsonConvert.SerializeObject(detailsData), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(int detailId)
        {
            var detail = detailsService.GetDetailById(detailId);
            return Json(JsonConvert.SerializeObject(detail), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public HttpStatusCodeResult Add(Detail detail)
        {
            if (ModelState.IsValid)
            {
                detailsService.Add(detail);

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public JsonResult MarkDeleted(int detailId)
        {
            detailsService.MarkDeleted(detailId);
            return Json(null);
        }

        [HttpPost]
        public JsonResult Delete(int detailId)
        {
            detailsService.Delete(detailId);
            return Json(null);
        }

        [HttpPost]
        public HttpStatusCodeResult Update(Detail detail)
        {
            if (ModelState.IsValid)
            {
                detailsService.Update(detail);

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public void AddQuantity(int detailId, int quantity)
        {
            detailsService.AddQuantity(detailId, quantity);
        }
    }
}