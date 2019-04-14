using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlexFileRenamer.Client.Serivices.EpisodeLoader;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using PlexFileRenamer.Interfaces.Services.LocalStorage;
using PlexFileRenamer.Interfaces.Services.SessionStorage;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Services.ApiServices.TheTvDb;
using PlexFileRenamer.Services.AppConfig;
using PlexFileRenamer.Services.LocalStorage;
using PlexFileRenamer.Services.SessionStorage;

namespace PlexFileRenamer.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAppConfigService, AppConfigService>();

            services.AddTransient<ILocalStorageService, LocalStorageService>();
            services.AddTransient<ISessionStorageService, SessionStorageService>();

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IEpisodeService, EpisodeService>();
            services.AddTransient<ILanguagesService, LanguagesService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<ISeriesService, SeriesService>();

            services.AddTransient<IEpisodeLoaderService, EpisodeLoaderService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
