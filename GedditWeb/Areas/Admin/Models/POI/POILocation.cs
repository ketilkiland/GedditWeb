using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Areas.Admin.Models.POI
{
    public class POILocation
    {
        public string Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}