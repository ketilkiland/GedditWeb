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

            return View();
        }
    }
}