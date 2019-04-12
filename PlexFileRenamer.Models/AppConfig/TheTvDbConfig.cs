using PlexFileRenamer.Models.ApiModels.TheTvDb.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Models.AppConfig
{
    public class TheTvDbConfig
    {
        public string ApiKey { get; set; }
        public string UserKey { get; set; }
        public string Username { get; set; }
        public string EndPoint { get; set; }
        public string Token { get; set; }
        public Language DefaultLanguage { get; set; }

        public TheTvDbConfig()
        {
            DefaultLanguage = new Language();
        }
    }
}
