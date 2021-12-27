using Experts.First_Project.Startup.Dtos;

using Abp.Extensions;

namespace Experts.First_Project.Web.Areas.App.Models.Governatates
{
    public class CreateOrEditGovernatateModalViewModel
    {
        public CreateOrEditGovernatateDto Governatate { get; set; }

        public bool IsEditMode => Governatate.Id.HasValue;
    }
}