using GedditWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Services.POI.DTO
{


    public class AspectDto
    {
        public string prefabKey { get; set; }
        public string textureKey { get; set; }
    }

    public class LocationDto
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class POIDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public AspectDto aspect { get; set; }
        public List<LocationDto> locations { get; set; }
    }

    public class CreatePOIRequest
    {
        public CreatePOIRequest(POIModel model)
        {
            POI = model;

            POIdto = new POIDto()
            {
                name = model.Name,
                description = model.Description,
                aspect = new AspectDto()
                {
                    prefabKey = model.AssetKey,
                    textureKey = ""
                },
                 locations = new List<LocationDto>()
                 {
                     new LocationDto()
                     {
                         type = "Point",
                         coordinates = new List<double>()
                         {
                             model.Latitude,
                             model.Longitude
                         }
                     }
                 }
            };
        }

        public POIModel POI { get; set; }
        public POIDto POIdto { get; set; }

    }
}