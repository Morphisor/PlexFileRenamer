using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Models.ApiModels.TheTvDb.Series
{
    public class SeriesResponse
    {
        public Series Data { get; set; }
        public JSONErrors Errors { get; set; }
    }
}
