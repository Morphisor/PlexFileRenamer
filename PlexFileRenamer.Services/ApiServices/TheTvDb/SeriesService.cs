using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Series;

namespace PlexFileRenamer.Services.ApiServices.TheTvDb
{
    public class SeriesService : TheTvDbBaseService, ISeriesService
    {
        public SeriesService(HttpClient httpClient, IAppConfigService appConfig, IAuthenticationService authService) : base(httpClient, appConfig, authService)
        {
        }

        public async Task<SeriesResponse> Series(int id)
        {
            var response = await GenericGet<SeriesResponse>($"{_appConfigService.TheTvDbConfig.EndPoint}/series/{id}", _authService.GetAuthHeader(), GetLanguageHeader());
            return response;
        }

        public async Task<SeriesEpisodesResponse> SeriesEpisodes(int id, int page = 1)
        {
            var response = await GenericGet<SeriesEpisodesResponse>($"{_appConfigService.TheTvDbConfig.EndPoint}/series/{id}/episodes?page={page}", _authService.GetAuthHeader(), GetLanguageHeader());
            return response;
        }
    }
}
