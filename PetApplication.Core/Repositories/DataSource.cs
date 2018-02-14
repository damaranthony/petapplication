using System.Threading.Tasks;
using PetApplication.Core.Common.Helpers;
using PetApplication.Core.Common.Config;

namespace PetApplication.Core.Repositories
{
    public class DataSource : IDataSource
    {
        public string GetApiResponseString()
        {
            return Task.Run(GetDataAsync).Result.ToString();
        }

        /// <summary>
        /// Gets the response from API 
        /// </summary>
        /// <returns>HTTP response as string</returns>
        private async Task<string> GetDataAsync()
        {
            var httpClient = BaseHttpClient.GetClient();
            var httpResponse = await httpClient.GetAsync(Configurator.People_Api);

            if (httpResponse.IsSuccessStatusCode)
            {
               return await httpResponse.Content.ReadAsStringAsync();
            }
           
            return string.Empty;
        }
    }
}
