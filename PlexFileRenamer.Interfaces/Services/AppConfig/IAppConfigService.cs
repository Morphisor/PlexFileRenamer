using PlexFileRenamer.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Interfaces.Services.AppConfig
{
    public interface IAppConfigService
    {
        TheTvDbConfig TheTvDbConfig { get; set; }
    }
}
