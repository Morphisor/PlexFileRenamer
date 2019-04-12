using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Interfaces.Services.LocalStorage
{
    public interface ILocalStorageService
    {
        Task<T> Get<T>(string key) where T : class;
        Task Set(string key, object value);
    }
}
