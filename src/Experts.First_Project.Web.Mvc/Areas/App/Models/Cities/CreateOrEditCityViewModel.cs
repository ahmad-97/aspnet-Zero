using Experts.First_Project.Setup.Dtos;

using Abp.Extensions;

namespace Experts.First_Project.Web.Areas.App.Models.Cities
{
    public class CreateOrEditCityModalViewModel
    {
        public CreateOrEditCityDto City { get; set; }

        public string GovernatateName { get; set; }

        public bool IsEditMode => City.Id.HasValue;
    }
}