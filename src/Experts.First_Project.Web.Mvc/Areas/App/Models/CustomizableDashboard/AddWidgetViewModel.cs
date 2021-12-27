using System.Collections.Generic;
using Experts.First_Project.DashboardCustomization.Dto;

namespace Experts.First_Project.Web.Areas.App.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}
