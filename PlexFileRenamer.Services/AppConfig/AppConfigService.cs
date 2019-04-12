using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Services.AppConfig
{
    public class AppConfigService : IAppConfigService
    {
        public string ApiKey { get; set; }
        public string UserKey { get; set; }
        public string Username { get; set; }
        public TheTvDbConfig TheTvDbConfig { get; set; }

        public AppConfigService()
        {
            TheTvDbConfig = new TheTvDbConfig();
        }
    }
}
