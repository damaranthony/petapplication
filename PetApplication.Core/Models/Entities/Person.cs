using System;
using System.Collections.Generic;

namespace PetApplication.Core.Models.Entities
{
    [Serializable]
    public class Person
    {
        /// <summary>
        /// Name of a person
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// String representation of Gender. 
        /// Note: values are "Male" or "Female"
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Age of the person
        /// </summary>
        public int Age { get; set; }        
        /// <summary>
        /// List of Pet objects owned by a person
        /// </summary>
        public List<Pet> Pets { get; set; }

        /// <summary>
        /// Override for Equals method to enable comparing of list of objects
        /// </summary>
        /// <param name="obj">Current Object</param>
        /// <returns>Returns true if all the properties are equal</returns>
        public override bool Equals(object obj)
        {
            return obj is Person pObj
                && Equals(Name, pObj.Name)
                && Equals(Gender, pObj.Gender)
                && Equals(Age, pObj.Age);
        }
       
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
