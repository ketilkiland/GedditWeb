using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using GedditWeb.Services.POI.DTO;

using GSS = GameSparks.NET.Services;

namespace GedditWeb.Services.POI
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

        public async Task<ServiceResult<CreatePOIResult>> CreatePOI(CreatePOIRequest request)
        {
            var logrequest = new GSS.Events.Requests.LogEventRequest("poiCreate", PlayerId);
            logrequest.ScriptData = request.POIdto;

            var response = await _eventService.LogEventRequestAsync(logrequest);

            return new ServiceResult<CreatePOIResult>(true, new CreatePOIResult());
        }

        public async Task<ServiceResult<GetPOIsResult>> GetPOIs(GetPOIsRequest request)
        {
            var logrequest = new GSS.Events.Requests.LogEventRequest("poiGetAll", PlayerId);

            var response = await _eventService.LogEventRequestAsync(logrequest);

            Console.WriteLine("Response: " + response.ScriptData);
           // response.ScriptData
           
            


            return new ServiceResult<GetPOIsResult>(true, CreateGetPOIsResult(response.ScriptData));
        }

        private GetPOIsResult CreateGetPOIsResult(List<POIDto> dto)
        {
            var result = new GetPOIsResult();
            result.POIs = new List<Models.POIModel>();

            int count = 1001;
            foreach (var dtoPoi in dto)
            {
                result.POIs.Add(new Models.POIModel()
                {
                    Id = count.ToString(),
                    Name = dtoPoi.name,
                    Description = dtoPoi.description,
                    AssetKey = dtoPoi.aspect.prefabKey,
                    Latitude = dtoPoi.locations.First().coordinates[0],
                    Longitude = dtoPoi.locations.First().coordinates[1],
                    PrizeName = ""
                });
            }

            return result;
        }

    }
}