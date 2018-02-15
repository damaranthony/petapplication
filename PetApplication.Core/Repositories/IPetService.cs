using PetApplication.Core.Models.Entities;
using System.Collections.Generic;

namespace PetApplication.Core.Repositories
{
    public interface IPetService
    {
        IEnumerable<Pet> GetAllCat(IEnumerable<Person> people);
        List<Pet> GetAllByAscendingPetName(IEnumerable<Pet> pets);
    }
}
