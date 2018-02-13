using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetApplication.Core.Models.Entities;
using PetApplication.Core.Common.Services;
using Newtonsoft.Json;
using PetApplication.Core.Common.Config;

namespace PetApplication.Core.Repositories
{
    public class PersonService : BaseService
    {
        private readonly IEnumerable<Person> People;

        public PersonService() 
            : base()
        {
            People = Task.Run(GetAll).Result;
        }

        private async Task<IEnumerable<Person>> GetAll()
        {
            var httpResponse = await _httpClient.GetAsync(Configurator.People_Api);

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

        public IEnumerable<Person> GetByGender(string gender)
        {
            return People.Where(x => x.Gender.ToLower().Contains(gender.ToLower()));
        }

        public IEnumerable<Pet> GetAllPet()
        {
            return People.SelectMany(p => p.Pets);            
        }
    }
}
