using PlexFileRenamer.Models.ApiModels.TheTvDb.Series;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Interfaces.Services.TheTvDb
{
    public interface ISeriesService
    {
        Task<SeriesResponse> Series(int id);
        Task<SeriesEpisodesResponse> SeriesEpisodes(int id, int page = 1);
    }
}
