using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.AppConfig;

namespace PlexFileRenamer.Server.Controllers.TheTvDbControllers
{
    public class SearchController : TheTvDbBaseController
    {
        private readonly ISearchService _searchService;

        public SearchController(IOptions<TheTvDbConfig> config, IAppConfigService appConfig, ISearchService searchService) : base(config, appConfig)
        {
            _searchService = searchService;
        }

        [HttpGet("search/series")]
        public async Task<IActionResult> Search([FromQuery]string name)
        {
            var response = await _searchService.Search(name);
            return Ok(response);
        }
    }
}
