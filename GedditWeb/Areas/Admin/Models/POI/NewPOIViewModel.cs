using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Areas.Admin.Models.POI
{
    public class NewPOIViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<POILocation> Locations { get; set; }

    }
}