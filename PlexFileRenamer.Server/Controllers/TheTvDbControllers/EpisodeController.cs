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
    public class EpisodeController : TheTvDbBaseController
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IOptions<TheTvDbConfig> config, IAppConfigService appConfig, IEpisodeService episodeService) : base(config, appConfig)
        {
            _episodeService = episodeService;
        }

        [HttpGet("episodes/{id}")]
        public async Task<IActionResult> Episode(int id)
        {
            var response = await _episodeService.Episode(id);
            return Ok(response);
        }
    }
}
