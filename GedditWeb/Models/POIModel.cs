using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Models
{
    public class POIModel
    {
        public string  Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AssetKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PrizeName { get; set; }
    }
}