using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Models.ApiModels.TheTvDb.Search
{
    public class Search
    {
        public string[] Aliases { get; set; }
        public string Banner { get; set; }
        public string FirstAired { get; set; }
        public int Id { get; set; }
        public string Network { get; set; }
        public string Overview { get; set; }
        public string SeriesName { get; set; }
        public string Slug { get; set; }
        public string Status { get; set; }
    }
}
