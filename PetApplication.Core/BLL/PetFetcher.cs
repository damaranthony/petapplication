using System.Linq;
using PetApplication.Core.Repositories;
using PetApplication.Core.Models.ViewModels;

namespace PetApplication.Core.BLL
{
    public class PetFetcher
    {
        private readonly IDataSource _dataSource;
        private readonly IPersonService _personService;
        private readonly IPetService _petService;

        public PetFetcher() { }

        public PetFetcher(
            IDataSource datasource,
            IPersonService personService,
            IPetService petService)
        {
            _dataSource = datasource;
            _personService = personService;
            _petService = petService;
        }
        /// <summary>
        /// Gets all pets segregated by owner's gender
        /// </summary>
        /// <returns>Returns PetViewModel for display</returns>
        public PetsViewModel GetAllPetsByOwnerGender()
        {
            //get response string from api
            var responseString = _dataSource.GetApiResponseString();
            //get owners by gender
            var femaleOwners = _personService.GetFemaleOwners(responseString).ToList();
            var maleOwners = _personService.GetMaleOwners(responseString).ToList();
            
            //get pets by owners
            var femaleOwnedCats = _petService.GetAllCat(femaleOwners).ToList();
            var maleOwnedCats = _petService.GetAllCat(maleOwners).ToList();
            //assign view model for display
            var petsViewModel = new PetsViewModel
            {
                FemaleOwned = _petService.GetAllByAscendingPetName(femaleOwnedCats),
                MaleOwned = _petService.GetAllByAscendingPetName(maleOwnedCats)
            };

            return petsViewModel;
        }
    }
}
