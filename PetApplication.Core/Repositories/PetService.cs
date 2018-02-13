
using System.Collections.Generic;
using System.Linq;
using PetApplication.Core.Models.Entities;
using PetApplication.Core.Common.Services;

namespace PetApplication.Core.Repositories
{
    public class PetService : IPetService
    {
        public IEnumerable<Pet> GetAll(List<Person> people)
        {
            return people.SelectMany(p => p.Pets);
        }

        public IEnumerable<Pet> GetByOwnerGender(string gender)
        {
            var personService = new PersonService();
            var people = personService.GetByGender(gender).Where(p => p.Pets != null).ToList();

            return GetAll(people);
        }

        public IEnumerable<Pet> GetByTypeGenderAsc(string type, string gender)
        {
            var pets = GetByOwnerGender(gender);

            return pets.Where(p => p.Type.ToLower().Contains(type.ToLower())).OrderBy(p => p.Name);
        }
    }
}
