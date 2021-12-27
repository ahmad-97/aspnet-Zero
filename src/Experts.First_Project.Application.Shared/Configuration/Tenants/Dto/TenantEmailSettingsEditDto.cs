using Abp.Auditing;
using Experts.First_Project.Configuration.Dto;

namespace Experts.First_Project.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}