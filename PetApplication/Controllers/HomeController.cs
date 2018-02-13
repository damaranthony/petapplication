using System.Linq;
using System.Web.Mvc;
using PetApplication.Core.BLL;
using PetApplication.Core.Common.Constants;
using PetApplication.Core.Models.ViewModels;

namespace PetApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
    }
}