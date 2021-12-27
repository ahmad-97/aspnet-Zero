using System.Collections.Generic;
using Experts.First_Project.DynamicEntityProperties.Dto;

namespace Experts.First_Project.Web.Areas.App.Models.DynamicProperty
{
    public class CreateOrEditDynamicPropertyViewModel
    {
        public DynamicPropertyDto DynamicPropertyDto { get; set; }

        public List<string> AllowedInputTypes { get; set; }
    }
}
