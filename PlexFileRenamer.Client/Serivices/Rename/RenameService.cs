using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public string GenerateBatchScript(List<Episode> seasonEpisodes, string[] files, int seasonIndex, string seriesName, string basePath)
        {
            var builder = new StringBuilder($"pushd {basePath} \n");

            for (int i = 0; i < files.Length; i++)
            {
                var file = files[i];
                var filename = Path.GetFileNameWithoutExtension(file);
                var fileExt = Path.GetExtension(file);
                var episode = seasonEpisodes[i];
                builder.Append($"ren \"{filename}{fileExt}\" \"{seriesName} - {seasonIndex + 1}x{episode.AiredEpisodeNumber?.ToString("D2")} - {episode.EpisodeName}{fileExt}\" \n");
            }

            builder.Append("popd");

            return builder.ToString();
        }
    }
}
