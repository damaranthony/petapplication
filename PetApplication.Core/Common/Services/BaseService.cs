using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using PetApplication.Core.Common.Helpers;

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
