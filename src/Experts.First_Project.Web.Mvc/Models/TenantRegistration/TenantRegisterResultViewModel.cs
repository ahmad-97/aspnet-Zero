using Abp.AutoMapper;
using Experts.First_Project.MultiTenancy.Dto;

namespace Experts.First_Project.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}