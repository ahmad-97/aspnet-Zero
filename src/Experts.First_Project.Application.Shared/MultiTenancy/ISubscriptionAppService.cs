using System.Threading.Tasks;
using Abp.Application.Services;

namespace Experts.First_Project.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
