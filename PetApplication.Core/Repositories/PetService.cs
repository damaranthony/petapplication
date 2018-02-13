
using System.Collections.Generic;
using System.Linq;
using PetApplication.Core.Models.Entities;
using PetApplication.Core.Common.Constants;

namespace PetApplication.Core.Repositories
{
    public class PetService : IPetService
    {
        public List<Pet> GetAllByAscendingPetName(List<Pet> pets)
        {
            return pets.OrderBy(p => p.Name).ToList();
        }

        public IEnumerable<Pet> GetAllCat(List<Person> people)
        {
            return people
                .SelectMany(p => p.Pets)
                .Where(p => p.Type.ToLower().Contains(PetType.Cat))
                .GroupBy(p => p.Name)
                .Select(grp => grp.FirstOrDefault());
        }
    }
}
