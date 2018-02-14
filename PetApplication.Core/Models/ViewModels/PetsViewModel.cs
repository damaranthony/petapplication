using System.Collections.Generic;
using PetApplication.Core.Models.Entities;

namespace PetApplication.Core.Models.ViewModels
{
    public class PetsViewModel
    {
        /// <summary>
        /// List of Pet objects from owners with gender "Female"
        /// </summary>
        public List<Pet> FemaleOwned { get; set; }
        /// <summary>
        /// List of Pet objects from owners with gender "Male"
        /// </summary>
        public List<Pet> MaleOwned { get; set; }
    }
}
