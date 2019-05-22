using Microsoft.AspNetCore.Components;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Pages
{
    public abstract class TheTvDbBasePage : ComponentBase
    {
        [Inject]
        private IAuthenticationService _authService { get; set; }

        [Inject]
        private IAppConfigService _appConfig { get; set; }

        private bool _isLoading;
        protected bool IsLoading
        {
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
            if (string.IsNullOrEmpty(_appConfig.TheTvDbConfig.Token))
            {
                IsLoading = true;
                _appConfig.TheTvDbConfig.EndPoint = "https://plexfilerenamerserver.azurewebsites.net/thetvdb";
                _appConfig.TheTvDbConfig.DefaultLanguage = new Language()
                {
                    Abbreviation = "en",
                    EnglishName = "English",
                    Name = "English",
                    Id = 7
                };
                await _authService.Login();
                IsLoading = false;
            }
        }
    }
}
