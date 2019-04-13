using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Languages;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Search;
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

        [Inject]
        private IJSRuntime _interop { get; set; }

        protected string SearchTerm { get; set; }
        protected SearchResponse SearchResult { get; set; }

        private bool _isLoading;
        protected bool IsLoading {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                StateHasChanged();
            }
        }

        protected override async void OnInit()
        {
            base.OnInit();
            _appConfig.TheTvDbConfig.EndPoint = "http://localhost:51392/thetvdb";
            _appConfig.TheTvDbConfig.DefaultLanguage = new Language()
            {
                Abbreviation = "en",
                EnglishName = "English",
                Name = "English",
                Id = 7
            };
            await _authService.Login();
            StateHasChanged();
        }

        protected async Task Search()
        {
            IsLoading = true;
            SearchResult = await _searchService.Search(SearchTerm);
            IsLoading = false;
        }

        protected async Task OnFilesSelected()
        {
            var files = await _interop.InvokeAsync<string[]>("blazorInterop.utils.getInputFiles", "inputGroupFile01");
            StateHasChanged();
        }
    }
}
