using Abp.AutoMapper;
using Experts.First_Project.MultiTenancy;
using Experts.First_Project.MultiTenancy.Dto;
using Experts.First_Project.Web.Areas.App.Models.Common;

namespace Experts.First_Project.Web.Areas.App.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }
    }
}