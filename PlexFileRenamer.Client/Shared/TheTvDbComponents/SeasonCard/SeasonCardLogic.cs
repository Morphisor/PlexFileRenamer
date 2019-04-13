using Microsoft.AspNetCore.Components;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Shared.TheTvDbComponents.SeasonCard
{
    public class SeasonCardLogic : ComponentBase
    {
        [Parameter]
        protected List<Episode> Episodes { get; set; }

        [Parameter]
        protected int SeasonIndex { get; set; }

        protected bool IsCollapsed { get; set; }

        protected override void OnInit()
        {
            base.OnInit();
            Episodes.OrderBy(ep => ep.AiredEpisodeNumber);
        }

        protected void Collapse()
        {
            IsCollapsed = !IsCollapsed;
        }
    }
}
