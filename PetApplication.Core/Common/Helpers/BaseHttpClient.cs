using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PetApplication.Core.Common.Helpers
{
    public static class BaseHttpClient
    {
        public static HttpClient GetClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Setting.ExternalApi)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
