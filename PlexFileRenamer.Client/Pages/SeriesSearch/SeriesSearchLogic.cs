using Microsoft.AspNetCore.Components;
using PlexFileRenamer.Interfaces.Services.TheTvDb;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Pages.SeriesSearch
{
    public class SeriesSearchLogic : TheTvDbBasePage
    {
        [Inject]
        private ISearchService _searchService { get; set; }

        protected string SearchTerm { get; set; }
        protected SearchResponse SearchResult { get; set; }

        protected async Task Search()
        {
            IsLoading = true;
            SearchResult = await _searchService.Search(SearchTerm);
            IsLoading = false;
        }
    }
}
