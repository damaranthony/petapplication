using System;

namespace PetApplication.Core.Models.Entities
{
    [Serializable]
    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// Override for Equals method to enable comparing of list of objects
        /// </summary>
        /// <param name="obj">Current Object</param>
        /// <returns>Returns true if all the properties are equal</returns>
        public override bool Equals(object obj)
        {
            var pObj = obj as Pet;

            return pObj != null
                && Equals(Name, pObj.Name)
                && Equals(Type, pObj.Type);
        }

        /// <summary>
        /// Override for GetHasCode method to make comparing of list of objects more comprehensive through hash codes
        /// </summary>
        /// <returns>Returns the hash code based on all the properties</returns>
        public override int GetHashCode()
        {
            int hc = 0x00;
            hc ^= (Name != null) ? Name.GetHashCode() : 0;
            hc ^= (Type != null) ? Type.GetHashCode() : 0;
            return hc;
        }
    }
}
