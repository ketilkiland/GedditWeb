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
            string credentials = "server";
            string secret = "iXxGLT92D3k9Gn8r4UGljcKmWUgUmqAk";
            bool isLive = false;

            GameSparksSettings.Set(apiKey, credentials, secret, isLive);
        }
    }
}