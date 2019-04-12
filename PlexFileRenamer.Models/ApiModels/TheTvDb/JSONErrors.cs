using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Models.ApiModels.TheTvDb
{
    public class JSONErrors
    {
        public string[] InvalidFilters { get; set; }
        public string InvalidLanguage { get; set; }
        public string[] InvalidQueryParams { get; set; }
    }
}
