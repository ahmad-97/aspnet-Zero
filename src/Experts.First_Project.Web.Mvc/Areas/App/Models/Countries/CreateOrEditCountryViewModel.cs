using Experts.First_Project.Setup.Dtos;

using Abp.Extensions;

namespace Experts.First_Project.Web.Areas.App.Models.Countries
{
    public class CreateOrEditCountryModalViewModel
    {
        public CreateOrEditCountryDto Country { get; set; }

        public bool IsEditMode => Country.Id.HasValue;
    }
}