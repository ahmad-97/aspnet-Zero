using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Experts.First_Project.EntityFrameworkCore;

namespace Experts.First_Project.HealthChecks
{
    public class First_ProjectDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public First_ProjectDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("First_ProjectDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("First_ProjectDbContext could not connect to database"));
        }
    }
}
