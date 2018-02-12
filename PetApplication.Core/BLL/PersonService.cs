using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetApplication.Core.Models;
using PetApplication.Core.Common.Services;
using Newtonsoft.Json;
namespace PetApplication.Core.BLL
{
    public class PersonService : BaseService
    {
        public PersonService() 
            : base()
        {
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            var httpResponse = await _httpClient.GetAsync("people.json");

            if (httpResponse.IsSuccessStatusCode)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<IEnumerable<Person>>(responseContent);
                return model;
            }
            else
            {
            }

            return new List<Person>();
        }
    }
}
