using System;

namespace PetApplication.Core.Models.Entities
{
    [Serializable]
    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
