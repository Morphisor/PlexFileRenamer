using System;
using System.Collections.Generic;
using System.Text;

namespace PlexFileRenamer.Models.ApiModels.TheTvDb.Authentication
{
    public class LoginRequest
    {
        public string ApiKey { get; set; }
        public string UserKey { get; set; }
        public string Username { get; set; }
    }
}
