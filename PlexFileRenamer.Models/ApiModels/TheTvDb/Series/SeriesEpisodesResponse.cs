using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Models.ApiModels.TheTvDb.Series
{
    public class SeriesEpisodesResponse
    {
        public List<Episode.Episode> Data { get; set; }
        public JSONErrors Errors { get; set; }
        public Links Links { get; set; }
    }
}
