namespace Experts.First_Project.MultiTenancy.HostDashboard.Dto
{
    public class ExpiringTenant
    {
        public string TenantName { get; set; }
        public int RemainingDayCount { get; set; }
    }
}