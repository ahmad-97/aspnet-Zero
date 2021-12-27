using Abp.AutoMapper;
using Experts.First_Project.Sessions.Dto;

namespace Experts.First_Project.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}