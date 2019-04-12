using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Services.ApiServices.TheTvDb
{
    public class AuthenticationService : ServiceBase, IAuthenticationService
    {
        public AuthenticationService(HttpClient httpClient, IAppConfigService appConfig) : base(httpClient, appConfig)
        {
        }

        public async Task Login()
        {
            var loginModel = new LoginRequest()
            {
                ApiKey = _appConfigService.ApiKey,
                UserKey = _appConfigService.UserKey,
                Username = _appConfigService.Username
            };
            var response = await GenericPost<LoginResponse>($"{_appConfigService.TheTvDbConfig.EndPoint}/login", loginModel);
            if(response != null)
            {
                _appConfigService.TheTvDbConfig.Token = response.Token;
            }
        }

        public async Task Refresh()
        {
            if (string.IsNullOrEmpty(_appConfigService.TheTvDbConfig.Token))
                throw new Exception("TheTVDb config does not contain a token to refresh!");

            var response = await GenericGet<LoginResponse>($" {_appConfigService.TheTvDbConfig.EndPoint}/refresh_token", GetAuthHeader());
            if(response != null)
            {
                _appConfigService.TheTvDbConfig.Token = response.Token;
            }
        }

        public AuthenticationHeaderValue GetAuthHeader()
        {
            if (string.IsNullOrEmpty(_appConfigService.TheTvDbConfig.Token))
                return null;

            var toReturn = new AuthenticationHeaderValue("Bearer", _appConfigService.TheTvDbConfig.Token);
            return toReturn;
        }
    }
}
