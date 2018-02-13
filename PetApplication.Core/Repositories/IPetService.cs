using PetApplication.Core.Models.Entities;
using System.Collections.Generic;

namespace PetApplication.Core.Repositories
{
    public interface IPetService
    {
        IEnumerable<Pet> GetAll(List<Person> people);

        IEnumerable<Pet> GetByOwnerGender(string gender);

        IEnumerable<Pet> GetByTypeGenderAsc(string type, string gender);
    }
}
