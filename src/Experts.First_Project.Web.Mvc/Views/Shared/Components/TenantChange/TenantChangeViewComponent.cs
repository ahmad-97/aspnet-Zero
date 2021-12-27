using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Experts.First_Project.Web.Session;

namespace Experts.First_Project.Web.Views.Shared.Components.TenantChange
{
    public class TenantChangeViewComponent : First_ProjectViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public TenantChangeViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionCache.GetCurrentLoginInformationsAsync();
            var model = ObjectMapper.Map<TenantChangeViewModel>(loginInfo);
            return View(model);
        }
    }
}
