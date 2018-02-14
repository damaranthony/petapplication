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
            var pObj = obj as Person;
           
            return pObj != null
                && Equals(Name, pObj.Name)
                && Equals(Gender, pObj.Gender)
                && Equals(Age, pObj.Age);
        }
        /// <summary>
        /// Override for GetHasCode method to make comparing of list of objects more comprehensive through hash codes
        /// </summary>
        /// <returns>Returns the hash code based on all the properties</returns>
        public override int GetHashCode()
        {
            int hc = 0x00;
            hc ^= (Name != null) ? Name.GetHashCode() : 0;
            hc ^= (Gender != null) ? Gender.GetHashCode() : 0;
            hc ^= Age.GetHashCode();
            return hc;
        }

    }
}
