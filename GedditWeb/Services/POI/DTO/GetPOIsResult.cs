using GedditWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Services.POI.DTO
{
    public class GetPOIsResult
    {

        public List<POIModel> POIs { get; set; }
    }
}