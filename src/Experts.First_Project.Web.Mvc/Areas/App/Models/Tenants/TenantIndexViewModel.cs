using System.Collections.Generic;
using Experts.First_Project.Editions.Dto;

namespace Experts.First_Project.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}