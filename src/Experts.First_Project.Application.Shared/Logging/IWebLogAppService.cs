using Abp.Application.Services;
using Experts.First_Project.Dto;
using Experts.First_Project.Logging.Dto;

namespace Experts.First_Project.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
