using GameSparks.NET.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.App_Start
{
    public class GamesparksConfig
    {
        public static void Initialize()
        {
            string apiKey = "R314803U8WmT";
            string credentials = "device";
            string secret = "NpGUEa0tenlxZqJwhcNfg3CfDixVYGyg";
            bool isLive = false;

            GameSparksSettings.Set(apiKey, credentials, secret, isLive);
        }
    }
}