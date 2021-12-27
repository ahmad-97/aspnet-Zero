using Microsoft.AspNetCore.Mvc;
using Experts.First_Project.Web.Controllers;

namespace Experts.First_Project.Web.Public.Controllers
{
    public class HomeController : First_ProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}