
using System.Collections.Generic;
using System.Linq;
using PetApplication.Core.Models.Entities;
using PetApplication.Core.Common.Constants;

namespace PetApplication.Core.Repositories
{
    public class PetService : IPetService
    {
        /// <summary>
        /// Arrange a list of Pet object by ascending name
        /// </summary>
        /// <param name="pets">Return a list of Pet object</param>
        /// <returns></returns>
        public List<Pet> GetAllByAscendingPetName(List<Pet> pets)
        {
            return pets.OrderBy(p => p.Name).ToList();
        }
        /// <summary>
        /// Get all pet cat from a list of Person object
        /// </summary>
        /// <param name="people">List of Person object</param>
        /// <returns>Returns a list of all cats</returns>
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
