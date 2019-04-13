using Microsoft.AspNetCore.Components;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;
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
        protected List<List<Episode>> SeasonEpisodes { get; set; }

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

            await RetrieveAllEpisodes();
        }

        private async Task RetrieveAllEpisodes()
        {
            AreEpisodesLoading = true;

            SeasonEpisodes = new List<List<Episode>>();
            var episodes = new List<Episode>();
            var firstPage = await _seriesService.SeriesEpisodes(int.Parse(SeriesId));
            episodes.AddRange(firstPage.Data);
            var currentPage = 1;
            var lastPage = firstPage.Links.Last;

            while (currentPage < lastPage)
            {
                currentPage += 1;
                var pageResponse = await _seriesService.SeriesEpisodes(int.Parse(SeriesId), currentPage);
                episodes.AddRange(pageResponse.Data);
            }

            episodes.OrderBy(ep => ep.AiredSeason);
            var maxSeason = episodes.Max(ep => ep.AiredSeason);
            for (int i = 1; i <= maxSeason; i++)
            {
                var seasonEpisodes = episodes.Where(ep => ep.AiredSeason == i).ToList();
                SeasonEpisodes.Add(seasonEpisodes);
            }

            AreEpisodesLoading = false;
        }
    }
}
