using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;

namespace PlexFileRenamer.Services.ApiServices.TheTvDb
{
    public abstract class TheTvDbBaseService : ServiceBase
    {
        protected readonly IAuthenticationService _authService;
        public TheTvDbBaseService(HttpClient httpClient, IAppConfigService appConfig, IAuthenticationService authService) : base(httpClient, appConfig)
        {
            _authService = authService;
        }

        protected KeyValuePair<string, string> GetLanguageHeader()
        {
            if (_appConfigService.TheTvDbConfig.DefaultLanguage == null)
                throw new Exception("The default language is null!");

            var toReturn = new KeyValuePair<string, string>("Accept-Language", _appConfigService.TheTvDbConfig.DefaultLanguage.Abbreviation);
            return toReturn;
        }
    }
}
