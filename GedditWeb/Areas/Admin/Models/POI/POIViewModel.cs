using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Areas.Admin.Models.POI
{

    public enum POICreationState
    {
        Description = 1,
        Location = 2,
        Prize = 3,
        Complete = 4
    };

    public class POIViewModel
    {
        public POICreationState State { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<POILocation> Locations { get; set; }

    }
}