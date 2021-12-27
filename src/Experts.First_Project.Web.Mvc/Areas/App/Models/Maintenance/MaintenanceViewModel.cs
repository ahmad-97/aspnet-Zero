using System.Collections.Generic;
using Experts.First_Project.Caching.Dto;

namespace Experts.First_Project.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}