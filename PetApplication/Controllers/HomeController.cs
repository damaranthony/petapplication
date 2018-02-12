using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PetApplication.Core.BLL;
using PetApplication.Core.Common.Constants;

namespace PetApplication.Controllers
{
    public class HomeController : Controller
    {
        private PetService _petService = new PetService();

        public ActionResult Index()
        {
            var femaleOwnerCats = _petService.GetByTypeGenderAsc(PetType.Cat, Gender.Female);
            var maleOwnerCats = _petService.GetByTypeGenderAsc(PetType.Cat, Gender.Male);

            return View();
        }
    }
}