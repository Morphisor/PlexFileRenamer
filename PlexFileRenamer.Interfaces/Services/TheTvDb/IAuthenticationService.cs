using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Interfaces.Services.TheTvDb
{
    public interface IAuthenticationService
    {
        Task Login();
        Task Refresh();
        AuthenticationHeaderValue GetAuthHeader();
    }
}
