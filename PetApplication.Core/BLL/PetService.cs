using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetApplication.Core.Models;
using PetApplication.Core.Common.Services;

namespace PetApplication.Core.BLL
{
    public class PetService : BaseService
    {
        public PetService() : base()
        {

        }
        
        public IEnumerable<Pet> GetAll()
        {
            var personService = new PersonService();
            var pets = personService.GetAllPet();

            return pets;
        }

        public IEnumerable<Pet> GetAll(List<Person> people)
        {
            return people.SelectMany(p => p.Pets);

        }

        public IEnumerable<Pet> GetByType(string type)
        {
            var pets = GetAll();

            return pets.Where(p => p.Type.ToLower().Contains(type.ToLower()));
        }

        public IEnumerable<Pet> GetByOwnerGender(string gender)
        {
            var personService = new PersonService();
            var people = personService.GetByGender(gender).ToList();

            return GetAll(people);
        }

        public IEnumerable<Pet> GetByTypeGenderAsc(string type, string gender)
        {
            var pets = GetByOwnerGender(gender);

            return pets.Where(p => p.Type.ToLower().Contains(type.ToLower())).OrderBy(p => p.Name);
        }
    }
}
