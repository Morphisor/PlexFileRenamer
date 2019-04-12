using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;

namespace PlexFileRenamer.Services.ApiServices.TheTvDb
{
    public class EpisodeService : TheTvDbBaseService, IEpisodeService
    {
        public EpisodeService(HttpClient httpClient, IAppConfigService appConfig, IAuthenticationService authService) : base(httpClient, appConfig, authService)
        {
        }

        public async Task<EpisodeResponse> Episode(int id)
        {
            var response = await GenericGet<EpisodeResponse>($"{_appConfigService.TheTvDbConfig.EndPoint}/episodes/{id}", _authService.GetAuthHeader(), GetLanguageHeader());
            return response;
        }

    }
}
