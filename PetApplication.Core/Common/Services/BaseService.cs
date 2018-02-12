
using System.Net.Http;
using PetApplication.Core.Common.Helpers;
using System.Collections.Generic;

namespace PetApplication.Core.Common.Services
{
    public abstract class BaseService
    {
        protected HttpClient _httpClient;

        protected BaseService()
        {
            _httpClient = BaseHttpClient.GetClient();
        }
    }
}
