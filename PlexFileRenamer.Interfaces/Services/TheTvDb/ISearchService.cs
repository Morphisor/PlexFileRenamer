using PlexFileRenamer.Models.ApiModels.TheTvDb.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Interfaces.Services.TheTvDb
{
    public interface ISearchService
    {
        Task<SearchResponse> Search(string name);
    }
}
