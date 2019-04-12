using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Search;

namespace PlexFileRenamer.Services.ApiServices.TheTvDb
{
    public class SearchService : TheTvDbBaseService, ISearchService
    {
        public SearchService(HttpClient httpClient, IAppConfigService appConfig, IAuthenticationService authService) : base(httpClient, appConfig, authService)
        {
        }

        public async Task<SearchResponse> Search(string name)
        {
            var encodedName = WebUtility.HtmlEncode(name);
            var response = await GenericGet<SearchResponse>($"{_appConfigService.TheTvDbConfig.EndPoint}/search/series?name={encodedName}", _authService.GetAuthHeader(), GetLanguageHeader());
            return response;
        }
    }
}
