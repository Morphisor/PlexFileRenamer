using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PlexFileRenamer.Client.Serivices.EpisodeLoader;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Pages.Rename
{
    public class RenameLogic : TheTvDbBasePage
    {
        [Parameter]
        protected string SeriesId { get; set; }

        [Inject]
        private ISeriesService _seriesService { get; set; }

        [Inject]
        private IEpisodeLoaderService _episodeLoaderService { get; set; }

        [Inject]
        private IJSRuntime _interop { get; set; }

        protected Series SeriesDetails { get; set; }
        protected List<List<Episode>> SeasonEpisodes { get; set; }
        protected string[] FileNames { get; set; }
        protected int SelectedSeason { get; set; }

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

        private bool _areEpisodesLoading;
        protected bool AreEpisodesLoading
        {
            get
            {
                return _areEpisodesLoading;
            }
            set
            {
                _areEpisodesLoading = value;
                StateHasChanged();
            }
        }

        protected override async void OnInit()
        {
            base.OnInit();
            IsLoading = true;
            var detailResult = await _seriesService.Series(int.Parse(SeriesId));

            if (detailResult != null)
                SeriesDetails = detailResult.Data;

            IsLoading = false;

            AreEpisodesLoading = true;
            SeasonEpisodes = await _episodeLoaderService.RetrieveAllEpisodes(int.Parse(SeriesId));
            AreEpisodesLoading = false;
        }

        protected async Task OnFilesSelected()
        {
            FileNames = await _interop.InvokeAsync<string[]>("blazorInterop.utils.getInputFiles", "inputGroupFile01");
            StateHasChanged();
        }
    }
}
