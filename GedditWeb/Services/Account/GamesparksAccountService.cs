using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GedditWeb.Services.Account.DTO;

using GSS = GameSparks.NET.Services;

namespace GedditWeb.Services.Account
{
    public class GamesparksAccountService : IAccountService
    {
        private GSS.GameSparksAuthenticationService _authenticationService;
        private GSS.GameSparksPlayerService _playerService;

        public GamesparksAccountService()
        {
            _authenticationService = new GSS.GameSparksAuthenticationService();
            _playerService = new GSS.GameSparksPlayerService();
        }


        public async Task<ServiceResult<AuthenticationResult>> Authenticate(string username, string password)
        {
            var request = new GSS.Authentication.Requests.AuthenticationRequest(username, password);

            var response = await _authenticationService.AuthenticationRequestAsync(request);

            if (response.Error == null)
            {
                return new ServiceResult<AuthenticationResult>(true, 
                    new AuthenticationResult()
                    {
                        UserID = response.UserId,
                        DisplayName = response.DisplayName,
                        Username = "",
                        Roles = null,
                    });
            }
            else
            {
                return new ServiceResult<AuthenticationResult>(false, "Wrong username or password");
            }

        }

        public async Task<ServiceResult<PlayerDetailsResult>> GetPlayerDetails(string playerId)
        {
            var request = new GSS.Player.Requests.AccountDetailsRequest(playerId);

            var response = await _playerService.AccountDetailsRequestAsync(request);

            if (response.Error == null)
            {
                return new ServiceResult<PlayerDetailsResult>(true,
                    new PlayerDetailsResult()
                    {
                          

                    });
            }
            else
            {
                return new ServiceResult<PlayerDetailsResult>(false, "Could not get player details");
            }
        }
    }
}