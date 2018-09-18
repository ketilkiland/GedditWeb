using GedditWeb.Services.Account.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GedditWeb.Services.Account
{
    public interface IAccountService
    {
        Task<ServiceResult<AuthenticationResult>> Authenticate(string username, string password);

        Task<ServiceResult<PlayerDetailsResult>> GetPlayerDetails(string playerId);
    }
}