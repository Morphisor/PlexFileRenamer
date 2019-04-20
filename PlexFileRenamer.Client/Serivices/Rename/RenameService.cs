using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Serivices.Rename
{
    public class RenameService : IRenameService
    {
        public string[]  MatchFilesToSeason(List<Episode> seasonEpisodes, string[] files)
        {
            Array.Sort(files);
            return files;
        }
    }
}
