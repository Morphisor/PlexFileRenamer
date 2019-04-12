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
    public class LanguageController : TheTvDbBaseController
    {
        private readonly ILanguagesService _languagesService;

        public LanguageController(IOptions<TheTvDbConfig> config, IAppConfigService appConfig, ILanguagesService languageService) : base(config, appConfig)
        {
            _languagesService = languageService;
        }

        [HttpGet("languages")]
        public async Task<IActionResult> Languages()
        {
            var response = await _languagesService.Languages();
            return Ok(response);
        }

        [HttpGet("languages/{id}")]
        public async Task<IActionResult> Language(int id)
        {
            var response = await _languagesService.Language(id);
            return Ok(response);
        }
    }
}
