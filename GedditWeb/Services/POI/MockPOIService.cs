using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GedditWeb.Models;
using GedditWeb.Services.POI.Requests;
using GedditWeb.Services.POI.Responses;

namespace GedditWeb.Services.POI
{
    public class MockPOIService : IPOIService
    {
        private List<POIModel> _pois = new List<POIModel>();
               

        public async Task<ServiceResult<CreatePOIResponse>> CreatePOI(CreatePOIRequest request)
        {
            return await Task.Run(() => 
            {
                POIModel poi = request.POI;

                poi.Id = (_pois.Count + 1001).ToString();
                _pois.Add(poi);

                return new ServiceResult<CreatePOIResponse>(true, new CreatePOIResponse() { POI = poi });
            });
        }

        public async Task<ServiceResult<GetPOIsResponse>> GetPOIs(GetPOIsRequest request)
        {
            return await Task.Run(() => 
            {
                return new ServiceResult<GetPOIsResponse>(true, new GetPOIsResponse() { POIs = _pois });
            });
        }
    }
}