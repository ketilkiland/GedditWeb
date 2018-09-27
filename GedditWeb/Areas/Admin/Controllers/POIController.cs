using GedditWeb.Areas.Admin.Models.POI;
using GedditWeb.Services.POI;
using GedditWeb.Services.POI.Requests;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GedditWeb.Areas.Admin.Controllers
{
    public class POIController : Controller
    {
        private IPOIService _poiService;

        public POIController(IPOIService poiService)
        {
            _poiService = poiService;
        }


        // GET: Admin/POI
        public async Task<ActionResult> Index()
        {
            var response = await _poiService.GetPOIs(new GetPOIsRequest());
           
            return View(response.Result.POIs);
        }


        public ActionResult Create()
        {
            return View("BasicPOIDetails");
        }


        private POIViewModel GetPOIViewModel()
        {
            if (Session["poi"] == null)
            {
                Session["poi"] = new POIViewModel();
            }

            return (POIViewModel)Session["poi"];
        }

        private void RemovePOIViewModel()
        {
            Session.Remove("poi");
        }


        [HttpPost]
        public ActionResult BasicPOIDetails(BasicPOIDetails data, string prevBtn, string nextBtn)
        {
            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    POIViewModel obj = GetPOIViewModel();
                    obj.Name = data.Name;
                    obj.Description = data.Description;

                    return View("ModelPOIDetails");
                }
            }

            return View();
        }



        [HttpPost]
        public ActionResult ModelPOIDetails(ModelPOIDetails data, string prevBtn, string nextBtn)
        {
            POIViewModel obj = GetPOIViewModel();

            if (prevBtn != null)
            {
                BasicPOIDetails bd = new BasicPOIDetails();
                bd.Name = obj.Name;
                bd.Description = obj.Description;
                return View("BasicPOIDetails", bd);
            }

            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    obj.AssetKey = data.AssetKey;
                    return View("LocationPOIDetails");
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult LocationPOIDetails(LocationPOIDetails data, string prevBtn, string nextBtn)
        {
            POIViewModel obj = GetPOIViewModel();

            if (prevBtn != null)
            {
                ModelPOIDetails md = new ModelPOIDetails();
                md.AssetKey = obj.AssetKey;                
                return View("ModelPOIDetails", md);
            }

            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    obj.Latitude = data.Latitude;
                    obj.Longitude = data.Longitude;
                    return View("PrizePOIDetails");
                }
            }

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> PrizePOIDetails(PrizePOIDetails data, string prevBtn, string nextBtn)
        {
            POIViewModel obj = GetPOIViewModel();

            if (prevBtn != null)
            {
                LocationPOIDetails ld = new LocationPOIDetails();
                ld.Latitude = obj.Latitude;
                ld.Longitude = obj.Longitude;

                return View("LocationPOIDetails", ld);
            }

            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    obj.PrizeName = data.PrizeName;

                    CreatePOIRequest request = new CreatePOIRequest(new GedditWeb.Models.POIModel()
                    {
                        Name = obj.Name,
                        Description = obj.Description,
                        AssetKey = obj.AssetKey,
                        Latitude = obj.Latitude,
                        Longitude = obj.Longitude,
                        PrizeName = obj.PrizeName
                    });

                    var response = await _poiService.CreatePOI(request);

                    RemovePOIViewModel();

                    return RedirectToAction("Index");                    
                }
            }

            return View();
        }




    }
}