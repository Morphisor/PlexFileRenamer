using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Server.Controllers.TheTvDbControllers
{
    [Route("thetvdb")]
    [ApiController]
    public class TheTvDbBaseController : Controller
    {
        protected readonly TheTvDbConfig _config;
        protected readonly IAppConfigService _appConfigService;

        public TheTvDbBaseController(IOptions<TheTvDbConfig> config, IAppConfigService appConfig)
        {
            _config = config.Value;
            _appConfigService = appConfig;
            _appConfigService.TheTvDbConfig.EndPoint = _config.EndPoint;
            _appConfigService.TheTvDbConfig.ApiKey = _config.ApiKey;
            _appConfigService.TheTvDbConfig.UserKey = _config.UserKey;
            _appConfigService.TheTvDbConfig.Username = _config.Username;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            HttpContext.Features.Get<IHttpBodyControlFeature>().AllowSynchronousIO = true;
            BuildAppConfig();
        }

        private void BuildAppConfig()
        {
            StringValues authHeader;
            if(Request.Headers.TryGetValue("Authorization", out authHeader))
            {
                _appConfigService.TheTvDbConfig.Token = authHeader.ToString().Split(' ')[1];
            }

            StringValues language;
            if(Request.Headers.TryGetValue("Accept-Language", out language))
            {
                _appConfigService.TheTvDbConfig.DefaultLanguage.Abbreviation = language.ToString();
            }
        }

    }
}
