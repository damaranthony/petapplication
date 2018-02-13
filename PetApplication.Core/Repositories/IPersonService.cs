using System;
using System.Collections.Generic;
using PetApplication.Core.Models.Entities;

namespace PetApplication.Core.Repositories
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll(string responseString);

        IEnumerable<Person> GetFemaleOwners(string responseString);

        IEnumerable<Person> GetMaleOwners(string responseString);
    }
}
