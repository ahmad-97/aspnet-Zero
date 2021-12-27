using Microsoft.AspNetCore.Antiforgery;

namespace Experts.First_Project.Web.Controllers
{
    public class AntiForgeryController : First_ProjectControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
