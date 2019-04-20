using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Serivices.Rename
{
    public interface IRenameService
    {
        string[] MatchFilesToSeason(List<Episode> seasonEpisodes, string[] files);
    }
}
