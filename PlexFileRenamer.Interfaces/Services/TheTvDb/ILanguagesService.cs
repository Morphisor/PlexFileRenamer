using PlexFileRenamer.Models.ApiModels.TheTvDb.Languages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Interfaces.Services.TheTvDb
{
    public interface ILanguagesService
    {
        Task<LanguagesResponse> Languages();
        Task<Language> Language(int id);
    }
}
