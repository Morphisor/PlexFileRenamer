using Microsoft.AspNetCore.Components;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Pages.TestPage
{
    public class TestPageLogic : ComponentBase
    {
        [Inject]
        private IAuthenticationService _authService { get; set; }

        [Inject]
        private ISearchService _searchService { get; set; }

        [Inject]
        private IAppConfigService _appConfig { get; set; }

        protected override void OnInit()
        {
            base.OnInit();
            _appConfig.ApiKey = "3XCUY2O2JFI475D7";
            _appConfig.UserKey = "LERUU731O96Z0JBV";
            _appConfig.Username = "morphisor000hal";
            _appConfig.TheTvDbConfig.EndPoint = "https://tvdbapiproxy.leonekmi.fr";
            _appConfig.TheTvDbConfig.DefaultLanguage = new Language()
            {
                Abbreviation = "en",
                EnglishName = "English",
                Name = "English",
                Id = 7
            };
        }

        protected async Task Test()
        {
            await _authService.Login();
            var result = await _searchService.Search("Narcos");
            Console.WriteLine(result);
        }
    }
}
