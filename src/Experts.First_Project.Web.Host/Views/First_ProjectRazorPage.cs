using Abp.AspNetCore.Mvc.Views;

namespace Experts.First_Project.Web.Views
{
    public abstract class First_ProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected First_ProjectRazorPage()
        {
            LocalizationSourceName = First_ProjectConsts.LocalizationSourceName;
        }
    }
}
