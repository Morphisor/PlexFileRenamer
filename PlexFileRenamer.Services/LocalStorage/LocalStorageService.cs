using Microsoft.JSInterop;
using PlexFileRenamer.Interfaces.Services.LocalStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Services.LocalStorage
{
    public class LocalStorageService : ILocalStorageService
    {
        private const string GET_INTEROP = "blazorInterop.localStorage.get";
        private const string SET_INTEROP = "blazorInterop.localStorage.set";

        private readonly IJSRuntime _interop;

        public LocalStorageService(IJSRuntime interop)
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
