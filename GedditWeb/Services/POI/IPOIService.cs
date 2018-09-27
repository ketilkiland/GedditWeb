using GedditWeb.Services.POI.Requests;
using GedditWeb.Services.POI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GedditWeb.Services.POI
{
    public interface IPOIService
    {
        Task<ServiceResult<CreatePOIResponse>> CreatePOI(CreatePOIRequest request);
        Task<ServiceResult<GetPOIsResponse>> GetPOIs(GetPOIsRequest request);
    }
}