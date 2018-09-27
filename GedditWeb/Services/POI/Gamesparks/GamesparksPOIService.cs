using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using GedditWeb.Models;
using GedditWeb.Services.POI.Requests;
using GedditWeb.Services.POI.Responses;
using GSS = GameSparks.NET.Services;

namespace GedditWeb.Services.POI.Gamesparks
{
    public class GamesparksPOIService : IPOIService
    {
        private GSS.GameSparksEventsService _eventService;
        private string _playerId;

        private string PlayerId
        {
            get
            {
                if (string.IsNullOrEmpty(_playerId))
                {
                    var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
                    if (claimsIdentity != null)
                    {
                        var userSIDClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid);

                        if (userSIDClaim != null)
                        {
                            _playerId = userSIDClaim.Value;
                        }
                    }
                }

                return _playerId;
            }
        }

        public GamesparksPOIService()
        {
            _eventService = new GSS.GameSparksEventsService();

        }

        public async Task<ServiceResult<CreatePOIResponse>> CreatePOI(CreatePOIRequest request)
        {
            var logrequest = new DTO.PoiCreateRequestDTO("poiCreate", PlayerId);

            logrequest.poi = new DTO.Pois()
                    {
                        name = request.POI.Name,
                        description = request.POI.Description,
                        aspect = new DTO.Aspect()
                        {
                            prefabKey = request.POI.AssetKey,
                            textureKey = ""
                        },
                        locations = new List<DTO.Location>()
                        {
                            new DTO.Location()
                            {
                                type = "Point",
                                coordinates = new List<double>()
                                {
                                    request.POI.Latitude,
                                    request.POI.Longitude
                                }
                            }
                        }
                    };

            var response = await _eventService.LogEventRequestAsync(logrequest);

            return new ServiceResult<CreatePOIResponse>(true, new CreatePOIResponse());
        }

        public async Task<ServiceResult<GetPOIsResponse>> GetPOIs(GetPOIsRequest request)
        {
            var logrequest = new GSS.Events.Requests.LogEventRequest("poiGetAll", PlayerId);

            var response = await _eventService.LogEventRequestAsync(logrequest);

            Console.WriteLine("Response: " + response.ScriptData);
            // response.ScriptData

            List<POIModel> result = new List<POIModel>();


            foreach (var poiData in response.ScriptData.pois)
            {
                POIModel poi = new POIModel();
                poi.Id = poiData.id;
                poi.Name = poiData.name;
                poi.Description = poiData.description;
                poi.AssetKey = poiData.aspect.prefabKey;
                poi.Latitude = poiData.locations[0].coordinates[0];
                poi.Longitude = poiData.locations[0].coordinates[1];

                result.Add(poi);                
            }

            return new ServiceResult<GetPOIsResponse>(true, new GetPOIsResponse() { POIs = result });
        }
    }
}