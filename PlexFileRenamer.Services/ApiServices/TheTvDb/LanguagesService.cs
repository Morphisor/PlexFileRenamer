using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Languages;

namespace PlexFileRenamer.Services.ApiServices.TheTvDb
{
    public class LanguagesService : TheTvDbBaseService, ILanguagesService
    {
        public LanguagesService(HttpClient httpClient, IAppConfigService appConfig, IAuthenticationService authService) : base(httpClient, appConfig, authService)
        {
        }

        public async Task<LanguagesResponse> Languages()
        {
            var response = await GenericGet<LanguagesResponse>($"{_appConfigService.TheTvDbConfig.EndPoint}/languages", _authService.GetAuthHeader());
            return response;
        }

        public async Task<Language> Language(int id)
        {
            var response = await GenericGet<Language>($"{_appConfigService.TheTvDbConfig.EndPoint}/languages/{id}", _authService.GetAuthHeader());
            return response;
        }
    }
}
