using PetApplication.Core.Models.Entities;
using System.Collections.Generic;

namespace PetApplication.Core.Repositories
{
    public interface IPetService
    {
        IEnumerable<Pet> GetAllCat(List<Person> people);
        List<Pet> GetAllByAscendingPetName(List<Pet> pets);
    }
}
