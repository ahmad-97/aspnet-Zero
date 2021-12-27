using Abp.AspNetCore.Mvc.ViewComponents;

namespace Experts.First_Project.Web.Public.Views
{
    public abstract class First_ProjectViewComponent : AbpViewComponent
    {
        protected First_ProjectViewComponent()
        {
            LocalizationSourceName = First_ProjectConsts.LocalizationSourceName;
        }
    }
}