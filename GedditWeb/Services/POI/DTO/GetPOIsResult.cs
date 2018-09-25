using GedditWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Services.POI.DTO
{
    public class GetPOIsResult
    {
        public GetPOIsResult(List<POIDto> dto)
        {
            POIs = new List<POIModel>();

            foreach (var poi in dto)
            {
                POIs.Add(new POIModel()
                {
                   //  Id = dto.
                });
            }
        }

        public List<POIModel> POIs { get; set; }
    }
}