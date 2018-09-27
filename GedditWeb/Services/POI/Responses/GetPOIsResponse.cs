using GedditWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Services.POI.Responses
{
    public class GetPOIsResponse
    {
        public List<POIModel> POIs { get; set; }
    }
}