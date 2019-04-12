using PlexFileRenamer.Models.ApiModels.TheTvDb.Episode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Interfaces.Services.TheTvDb
{
    public interface IEpisodeService
    {
        Task<EpisodeResponse> Episode(int id);
    }
}
