using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PetApplication.Core.BLL;

namespace PetApplication.Controllers
{
    public class HomeController : Controller
    {
        PersonService personService = new PersonService();

        public ActionResult Index()
        {
            var people = personService.GetPeople();

            return View();
        }

       
    }
}