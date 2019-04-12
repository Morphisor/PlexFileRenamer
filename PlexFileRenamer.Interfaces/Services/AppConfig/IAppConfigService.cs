using PlexFileRenamer.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Interfaces.Services.AppConfig
{
    public interface IAppConfigService
    {
        string ApiKey { get; set; }
        string UserKey { get; set; }
        string Username { get; set; }
        TheTvDbConfig TheTvDbConfig { get; set; }
    }
}
