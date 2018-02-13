using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PetApplication.Core.Repositories;
using PetApplication.Core.Models.ViewModels;
using PetApplication.Core.Models.Entities;

namespace PetApplication.Core.BLL
{
    public class PetFetcher
    {
        private readonly IDataSource _dataSource;
        private readonly IPersonService _personService;
        private readonly IPetService _petService;

        public PetFetcher(
            IDataSource datasource,
            IPersonService personService,
            IPetService petService)
        {
            _dataSource = datasource;
            _personService = personService;
            _petService = petService;
        }

        public PetsViewModel GetAllPetsByOwnerGender()
        {
            var responseString = Task.Run(_dataSource.GetDataAsync).Result;
            
            var femaleOwners = _personService.GetFemaleOwners(responseString).ToList();
            var maleOwners = _personService.GetMaleOwners(responseString).ToList();

            var femaleOwnedCats = _petService.GetAllCat(femaleOwners).ToList();
            var maleOwnedCats = _petService.GetAllCat(maleOwners).ToList();

            var petsViewModel = new PetsViewModel
            {
                FemaleOwned = _petService.GetAllByAscendingPetName(femaleOwnedCats),
                MaleOwned = _petService.GetAllByAscendingPetName(maleOwnedCats)
            };

            return petsViewModel;
        }
    }
}
