using AtlantTest.Database;
using AtlantTest.Entities;
using AtlantTest.Repositories;
using AtlantTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AtlantTest.Controllers
{
    public class StorekeepersController : Controller
    {
        private IStorekeepersService storekeepersService;

        public StorekeepersController(IStorekeepersService storekeepersService)
        {
            this.storekeepersService = storekeepersService;
        }

        public ActionResult All()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            var storekeepers = storekeepersService.GetAllStorekeepersData();
            return Json(storekeepers, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public HttpStatusCodeResult Add(Storekeeper storekeeper)
        {
            if (ModelState.IsValid)
            {
                storekeepersService.AddStorekeeper(storekeeper);

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}