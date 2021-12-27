using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Experts.First_Project.MultiTenancy.HostDashboard.Dto;

namespace Experts.First_Project.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}