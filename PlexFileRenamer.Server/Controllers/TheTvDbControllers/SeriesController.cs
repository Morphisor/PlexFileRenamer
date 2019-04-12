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
    public class SeriesController : TheTvDbBaseController
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(IOptions<TheTvDbConfig> config, IAppConfigService appConfig, ISeriesService seriesService) : base(config, appConfig)
        {
            _seriesService = seriesService;
        }

        [HttpGet("series/{id}")]
        public async Task<IActionResult> Series(int id)
        {
            var response = await _seriesService.Series(id);
            return Ok(response);
        }

        [HttpGet("series/{id}/episodes")]
        public async Task<IActionResult> SeriesEpisodes(int id, [FromQuery] int page = 1)
        {
            var response = await _seriesService.SeriesEpisodes(id, page);
            return Ok(response);
        }
    }
}
