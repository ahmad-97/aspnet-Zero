using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Experts.First_Project.Web.Areas.App.Models.Layout;
using Experts.First_Project.Web.Views;

namespace Experts.First_Project.Web.Areas.App.Views.Shared.Components.
    AppQuickThemeSelect
{
    public class AppQuickThemeSelectViewComponent : First_ProjectViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass)
        {
            return Task.FromResult<IViewComponentResult>(View(new QuickThemeSelectionViewModel
            {
                CssClass = cssClass
            }));
        }
    }
}
