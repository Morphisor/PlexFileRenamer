using Microsoft.JSInterop;
using PlexFileRenamer.Interfaces.Services.SessionStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Services.SessionStorage
{
    public class SessionStorageService : ISessionStorageService
    {
        private const string GET_INTEROP = "blazorInterop.sessionStorage.get";
        private const string SET_INTEROP = "blazorInterop.sessionStorage.set";

        private readonly IJSRuntime _interop;

        public SessionStorageService(IJSRuntime interop)
        {
            _interop = interop;
        }

        public async Task<T> Get<T>(string key) where T : class
        {
            var res = await _interop.InvokeAsync<T>(GET_INTEROP, key);
            return res;
        }

        public async Task Set(string key, object value)
        {
            await _interop.InvokeAsync<bool>(SET_INTEROP, key, value);
        }
    }
}
