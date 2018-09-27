using GameSparks.NET.Services.Events.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Services.POI.DTO
{

    public class Aspect
    {
        public string prefabKey { get; set; }
        public string textureKey { get; set; }
    }

    public class Location
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Pois
    {
        public string name { get; set; }
        public string description { get; set; }
        public Aspect aspect { get; set; }
        public List<Location> locations { get; set; }
        public string id { get; set; }
    }

    public class Poi
    {
        public Pois poi { get; set; }
    }

    public class POIDTO
    {
        public List<Pois> pois { get; set; }
    }


    public class PoiCreateRequestDTO : LogEventRequest
    {

        public PoiCreateRequestDTO(string eventKey, string playerId, string requestId = "") : base(eventKey, playerId, requestId)
        { }
                
        [JsonProperty("poi")]
        public Pois poi { get; set; }
    }


}