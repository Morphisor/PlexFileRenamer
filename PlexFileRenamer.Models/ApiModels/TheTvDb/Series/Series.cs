using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Models.ApiModels.TheTvDb.Series
{
    public class Series
    {
        public string Added { get; set; }
        public string AirsDayOfWeek { get; set; }
        public string AirsTime { get; set; }
        public string[] Aliases { get; set; }
        public string Banner { get; set; }
        public string FirstAired { get; set; }
        public string[] Genre { get; set; }
        public int Id { get; set; }
        public string ImdbId { get; set; }
        public int LastUpdated { get; set; }
        public string Network { get; set; }
        public string NetworkId { get; set; }
        public string Overview { get; set; }
        public string Rating { get; set; }
        public string Runtime { get; set; }
        public string SeriesId { get; set; }
        public string SeriesName { get; set; }
        public float SiteRating { get; set; }
        public int SiteRatingCount { get; set; }
        public string Slug { get; set; }
        public string Status { get; set; }
        public string Zap2itId { get; set; }
    }
}
