using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PetApplication.Core.BLL;
using PetApplication.Core.Common.Constants;
using PetApplication.Core.Common.Extensions;
using PetApplication.Core.Models.ViewModels;

namespace PetApplication.Controllers
{
    public class HomeController : Controller
    {
        private PetService _petService = new PetService();


        public ActionResult Index()
        {
            var petsViewModel = new PetsViewModel
            {
                FemaleOwned = _petService.GetByTypeGenderAsc(PetType.Cat, Gender.Female).ToList(),
                MaleOwned = _petService.GetByTypeGenderAsc(PetType.Cat, Gender.Male).ToList()
            };

            return View(petsViewModel);
        }
    }
}