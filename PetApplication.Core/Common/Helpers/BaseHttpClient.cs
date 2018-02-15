using System;
using System.Net.Http;
using System.Net.Http.Headers;
using PetApplication.Core.Common.Config;

namespace PetApplication.Core.Common.Helpers
{
    public static class BaseHttpClient
    {
        /// <summary>
        /// Returns the HttpClient based on the default API from App Config
        /// </summary>
        /// <returns>Returns the HttpClient</returns>
        public static HttpClient GetClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Configurator.BaseApi)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Configurator.DefaultMediaType));

            return client;
        }
    }
}
