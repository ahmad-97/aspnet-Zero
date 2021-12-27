using System.Threading.Tasks;
using Abp.Application.Services;
using Experts.First_Project.Configuration.Host.Dto;

namespace Experts.First_Project.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
