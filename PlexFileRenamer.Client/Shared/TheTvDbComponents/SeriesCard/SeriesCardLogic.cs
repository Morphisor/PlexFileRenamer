using Microsoft.AspNetCore.Components;
using PlexFileRenamer.Models.ApiModels.TheTvDb.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Shared.TheTvDbComponents.SeriesCard
{
    public class SeriesCardLogic : ComponentBase
    {
        [Parameter]
        protected Search Series { get; set; }

        protected override void OnInit()
        {
            base.OnInit();
            Console.WriteLine("init Series card");
        }
    }
}
