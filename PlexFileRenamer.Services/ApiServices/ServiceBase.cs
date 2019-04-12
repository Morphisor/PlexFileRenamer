using Newtonsoft.Json;
using PlexFileRenamer.Interfaces.Services.AppConfig;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PlexFileRenamer.Services.ApiServices
{
    public abstract class ServiceBase
    {
        private readonly HttpClient _httpClient;

        protected readonly IAppConfigService _appConfigService;

        public ServiceBase(HttpClient httpClient, IAppConfigService appConfig)
        {
            _httpClient = httpClient;
            _appConfigService = appConfig;
        }

        protected async Task<T> GenericGet<T>(string url, AuthenticationHeaderValue authHeader = null, KeyValuePair<string, string>? languageHeader = null)
        {
            var toReturn = default(T);

            AddDefaultHeaders(authHeader, languageHeader);

            try
            {
                var res = await _httpClient.GetAsync(url);
                if(res.StatusCode == HttpStatusCode.OK)
                {
                    var stringResult = await res.Content.ReadAsStringAsync();
                    toReturn = JsonConvert.DeserializeObject<T>(stringResult);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return toReturn;
        }

        protected async Task<T> GenericPost<T>(string url, object body, AuthenticationHeaderValue authHeader = null, KeyValuePair<string, string>? languageHeader = null)
        {
            var toReturn = default(T);

            AddDefaultHeaders(authHeader, languageHeader);

            try
            {
                var serializedBody = JsonConvert.SerializeObject(body);
                var buffer = Encoding.UTF8.GetBytes(serializedBody);
                var content = new ByteArrayContent(buffer);
                content.Headers.Add("Content-Type", "application/json");

                var res = await _httpClient.PostAsync(url, content);
                if(res.StatusCode == HttpStatusCode.OK)
                {
                    var stringResult = await res.Content.ReadAsStringAsync();
                    toReturn = JsonConvert.DeserializeObject<T>(stringResult);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return toReturn;
        }

        private void AddDefaultHeaders(AuthenticationHeaderValue authHeader = null, KeyValuePair<string, string>? languageHeader = null)
        {
            if (authHeader != null)
                _httpClient.DefaultRequestHeaders.Authorization = authHeader;

            if (languageHeader.HasValue)
                _httpClient.DefaultRequestHeaders.Add(languageHeader.Value.Key, languageHeader.Value.Value);

            if(!_httpClient.DefaultRequestHeaders.Contains("Accept"))
                _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
        }
    }
}
