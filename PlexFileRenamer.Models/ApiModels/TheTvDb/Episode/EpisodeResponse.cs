using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Models.ApiModels.TheTvDb.Episode
{
    public class EpisodeResponse
    {
        public Episode Data { get; set; }
        public JSONErrors Errors { get; set; }
    }
}
