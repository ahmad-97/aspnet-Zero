using System.Threading.Tasks;
using Abp.Application.Services;
using Experts.First_Project.Install.Dto;

namespace Experts.First_Project.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}