using System;

namespace PetApplication.Core.Models.Entities
{
    [Serializable]
    public class Pet
    {
        /// <summary>
        /// The string name of a pet
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// String representation of type of pet
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Override for Equals method to enable comparing of list of objects
        /// </summary>
        /// <param name="obj">Current Object</param>
        /// <returns>Returns true if all the properties are equal</returns>
        public override bool Equals(object obj)
        {
            return obj is Pet pObj
                && Equals(Name, pObj.Name)
                && Equals(Type, pObj.Type);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
