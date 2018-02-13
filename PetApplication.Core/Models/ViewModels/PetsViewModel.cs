using System.Collections.Generic;
using PetApplication.Core.Models.Entities;

namespace PetApplication.Core.Models.ViewModels
{
    public class PetsViewModel
    {
        public List<Pet> FemaleOwned { get; set; }
        public List<Pet> MaleOwned { get; set; }
    }
}
