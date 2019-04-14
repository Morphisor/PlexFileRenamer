using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Serivices.EpisodeLoader
{
    public interface IEpisodeLoaderService
    {
        Task<List<List<Episode>>> RetrieveAllEpisodes(int seriesId);
    }
}
