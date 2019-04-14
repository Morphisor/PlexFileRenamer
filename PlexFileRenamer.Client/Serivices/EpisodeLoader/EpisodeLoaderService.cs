using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Serivices.EpisodeLoader
{
    public class EpisodeLoaderService : IEpisodeLoaderService
    {
        private readonly ISeriesService _seriesService;

        public EpisodeLoaderService(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        public async Task<List<List<Episode>>> RetrieveAllEpisodes(int seriesId)
        {
            var result = new List<List<Episode>>();
            var episodes = new List<Episode>();
            var firstPage = await _seriesService.SeriesEpisodes(seriesId);
            episodes.AddRange(firstPage.Data);
            var currentPage = 1;
            var lastPage = firstPage.Links.Last;

            while (currentPage < lastPage)
            {
                currentPage += 1;
                var pageResponse = await _seriesService.SeriesEpisodes(seriesId, currentPage);
                episodes.AddRange(pageResponse.Data);
            }

            episodes.OrderBy(ep => ep.AiredSeason);
            var maxSeason = episodes.Max(ep => ep.AiredSeason);
            for (int i = 1; i <= maxSeason; i++)
            {
                var seasonEpisodes = episodes.Where(ep => ep.AiredSeason == i).ToList();
                result.Add(seasonEpisodes);
            }

            return result;
        }
    }
}
