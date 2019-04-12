using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Interfaces.Services.SessionStorage
{
    public interface ISessionStorageService
    {
        Task<T> Get<T>(string key) where T : class;
        Task Set(string key, object value);
    }
}
