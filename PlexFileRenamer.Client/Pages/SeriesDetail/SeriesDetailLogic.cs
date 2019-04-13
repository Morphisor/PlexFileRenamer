using Microsoft.AspNetCore.Components;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Pages.SeriesDetail
{
    public class SeriesDetailLogic : TheTvDbBasePage
    {
        [Parameter]
        protected string SeriesId { get; set; }

        [Inject]
        private ISeriesService _seriesService { get; set; }

        protected Series SeriesDetails { get; set; }
        protected SeriesEpisodesResponse EpisodePage { get; set; }

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
            IsLoading = true;
            var detailResult = await _seriesService.Series(int.Parse(SeriesId));
            EpisodePage = await _seriesService.SeriesEpisodes(int.Parse(SeriesId));

            if (detailResult != null)
                SeriesDetails = detailResult.Data;

            IsLoading = false;
        }
    }
}
