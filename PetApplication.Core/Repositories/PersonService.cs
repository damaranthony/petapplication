using System.Collections.Generic;
using System.Linq;
using PetApplication.Core.Models.Entities;
using PetApplication.Core.Common.Constants;
using PetApplication.Core.Common.Extensions;

namespace PetApplication.Core.Repositories
{
    public class PersonService : IPersonService
    {
        /// <summary>
        /// Returns a list of Person object based on deserialized string
        /// </summary>
        /// <param name="responseString">HTTP response string</param>
        /// <returns>Returns list of Person object</returns>
        public IEnumerable<Person> GetAll(string responseString)
        {
            return responseString.ToPersonEntities();
        }
        /// <summary>
        /// Returns a list of Person object by gender female
        /// </summary>
        /// <param name="responseString">HTTP response string</param>
        /// <returns>Returns list of Person object</returns>
        public IEnumerable<Person> GetFemaleOwners(string responseString)
        {
            var people = responseString.ToPersonEntities();

            return people.Where(x => x.Gender.ToLower() == Gender.Female && x.Pets != null);
        }
        /// <summary>
        /// Returns a list of Person object by gender male
        /// </summary>
        /// <param name="responseString">HTTP response string</param>
        /// <returns>Returns a list of Person object</returns>
        public IEnumerable<Person> GetMaleOwners(string responseString)
        {
            var people = responseString.ToPersonEntities();

            return people.Where(x => x.Gender.ToLower() == Gender.Male && x.Pets != null);
        }

    }
}
