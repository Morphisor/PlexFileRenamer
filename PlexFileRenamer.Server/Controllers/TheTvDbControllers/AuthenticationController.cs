using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Server.Controllers.TheTvDbControllers
{
    public class AuthenticationController : TheTvDbBaseController
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IOptions<TheTvDbConfig> config, IAppConfigService appConfig, IAuthenticationService authService) : base(config, appConfig)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            var result = await _authService.Login();
            return Ok(result);
        }
    }
}
