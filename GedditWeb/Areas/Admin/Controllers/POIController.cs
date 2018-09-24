using GedditWeb.Areas.Admin.Models.POI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GedditWeb.Areas.Admin.Controllers
{
    public class POIController : Controller
    {
        // GET: Admin/POI
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            POIViewModel model = new POIViewModel() { State = POICreationState.Description };

            return View(model);
        }


        [HttpPost]
        public ActionResult Create(POIViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            switch (model.State)
            {
                case POICreationState.Description:
                    model.State = POICreationState.Location;
                    break;

                case POICreationState.Location:
                    model.State = POICreationState.Prize;
                    break; 

                case POICreationState.Prize:
                    //Last step, save POI and redirect to index
                    return RedirectToAction("Index", "POI");
            }


            return View(model);
        }






    }
}