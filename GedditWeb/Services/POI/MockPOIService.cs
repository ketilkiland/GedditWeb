using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GedditWeb.Models;
using GedditWeb.Services.POI.DTO;

namespace GedditWeb.Services.POI
{
    public class MockPOIService : IPOIService
    {
        private List<POIModel> _pois = new List<POIModel>();
               

        public async Task<ServiceResult<CreatePOIResult>> CreatePOI(CreatePOIRequest request)
        {
            return await Task.Run(() => 
            {
                POIModel poi = request.POI;

                poi.Id = (_pois.Count + 1001).ToString();
                _pois.Add(poi);

                return new ServiceResult<CreatePOIResult>(true, new CreatePOIResult() { POI = poi });
            });
        }

        public async Task<ServiceResult<GetPOIsResult>> GetPOIs(GetPOIsRequest request)
        {
            return await Task.Run(() => 
            {
                return new ServiceResult<GetPOIsResult>(true, new GetPOIsResult(null) { POIs = _pois });
            });
        }
    }
}