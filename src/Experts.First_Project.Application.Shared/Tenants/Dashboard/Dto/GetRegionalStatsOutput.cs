using System.Collections.Generic;

namespace Experts.First_Project.Tenants.Dashboard.Dto
{
    public class GetRegionalStatsOutput
    {
        public GetRegionalStatsOutput(List<RegionalStatCountry> stats)
        {
            Stats = stats;
        }

        public GetRegionalStatsOutput()
        {
            Stats = new List<RegionalStatCountry>();
        }

        public List<RegionalStatCountry> Stats { get; set; }

    }
}