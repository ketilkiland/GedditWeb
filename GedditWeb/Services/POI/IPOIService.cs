using GedditWeb.Services.POI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GedditWeb.Services.POI
{
    public interface IPOIService
    {
        Task<ServiceResult<CreatePOIResult>> CreatePOI(CreatePOIRequest request);
    }
}