using Abp.Events.Bus;

namespace Experts.First_Project.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}