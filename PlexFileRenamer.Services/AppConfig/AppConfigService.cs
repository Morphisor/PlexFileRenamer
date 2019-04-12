using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Services.AppConfig
{
    public class AppConfigService : IAppConfigService
    {
        public TheTvDbConfig TheTvDbConfig { get; set; }

        public AppConfigService()
        {
            TheTvDbConfig = new TheTvDbConfig();
        }
    }
}
