using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Experts.First_Project.Web.Public.Views
{
    public abstract class First_ProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected First_ProjectRazorPage()
        {
            LocalizationSourceName = First_ProjectConsts.LocalizationSourceName;
        }
    }
}
