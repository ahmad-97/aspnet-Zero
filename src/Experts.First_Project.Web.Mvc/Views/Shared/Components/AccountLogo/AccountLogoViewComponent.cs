using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Experts.First_Project.Web.Session;

namespace Experts.First_Project.Web.Views.Shared.Components.AccountLogo
{
    public class AccountLogoViewComponent : First_ProjectViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AccountLogoViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string skin)
        {
            var loginInfo = await _sessionCache.GetCurrentLoginInformationsAsync();
            return View(new AccountLogoViewModel(loginInfo, skin));
        }
    }
}
