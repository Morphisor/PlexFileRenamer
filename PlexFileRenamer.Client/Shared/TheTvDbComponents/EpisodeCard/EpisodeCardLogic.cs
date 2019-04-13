using Microsoft.AspNetCore.Components;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Shared.TheTvDbComponents.EpisodeCard
{
    public class EpisodeCardLogic : ComponentBase
    {
        [Parameter]
        protected Episode Episode { get; set; }
    }
}
