using GedditWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Services.POI.Requests
{
    public class CreatePOIRequest
    {
        public CreatePOIRequest(POIModel model)
        {
            POI = model;
        }

        public POIModel POI { get; set; }       
    }
}