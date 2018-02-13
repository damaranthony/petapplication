using System.Web.Mvc;
using PetApplication.Core.BLL;
using PetApplication.Core.Repositories;

namespace PetApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataSource _dataSource = new DataSource();
        private readonly IPetService _petService = new PetService();
        private readonly IPersonService _personService = new PersonService();

        public ActionResult Index()
        {
            var petFetcher = new PetFetcher(_dataSource, _personService, _petService);

            return View(petFetcher.GetAllPetsByOwnerGender());
        }
    }
}