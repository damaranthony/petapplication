using System;
using System.Net.Http;
using System.Net.Http.Headers;
using PetApplication.Core.Common.Config;
using PetApplication.Core.Common.Constants;

namespace PetApplication.Core.Common.Helpers
{
    public static class BaseHttpClient
    {
        public static HttpClient GetClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Configurator.Base_Api)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
