using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GedditWeb.Services.POI.DTO;

namespace GedditWeb.Services.POI
{
    public class MockPOIService : IPOIService
    {
        public Task<ServiceResult<CreatePOIResult>> CreatePOI(CreatePOIRequest request)
        {
            throw new NotImplementedException();
        }
    }
}