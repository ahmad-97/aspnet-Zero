using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Experts.First_Project.Web.Areas.App.Models.Layout;
using Experts.First_Project.Web.Session;
using Experts.First_Project.Web.Views;

namespace Experts.First_Project.Web.Areas.App.Views.Shared.Themes.Theme7.Components.AppTheme7Brand
{
    public class AppTheme7BrandViewComponent : First_ProjectViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme7BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
