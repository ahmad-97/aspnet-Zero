using System.Threading.Tasks;
using Abp.Application.Services;
using Experts.First_Project.Configuration.Tenants.Dto;

namespace Experts.First_Project.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
