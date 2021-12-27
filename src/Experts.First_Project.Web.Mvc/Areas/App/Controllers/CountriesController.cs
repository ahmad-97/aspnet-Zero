using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Experts.First_Project.Web.Areas.App.Models.Countries;
using Experts.First_Project.Web.Controllers;
using Experts.First_Project.Authorization;
using Experts.First_Project.Setup;
using Experts.First_Project.Setup.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace Experts.First_Project.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Countries)]
    public class CountriesController : First_ProjectControllerBase
    {
        private readonly ICountriesAppService _countriesAppService;

        public CountriesController(ICountriesAppService countriesAppService)
        {
            _countriesAppService = countriesAppService;

        }

        public ActionResult Index()
        {
            var model = new CountriesViewModel
            {
                FilterText = ""
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Countries_Create, AppPermissions.Pages_Countries_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetCountryForEditOutput getCountryForEditOutput;

            if (id.HasValue)
            {
                getCountryForEditOutput = await _countriesAppService.GetCountryForEdit(new EntityDto { Id = (int)id });
            }
            else
            {
                getCountryForEditOutput = new GetCountryForEditOutput
                {
                    Country = new CreateOrEditCountryDto()
                };
            }

            var viewModel = new CreateOrEditCountryModalViewModel()
            {
                Country = getCountryForEditOutput.Country,

            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> ViewCountryModal(int id)
        {
            var getCountryForViewDto = await _countriesAppService.GetCountryForView(id);

            var model = new CountryViewModel()
            {
                Country = getCountryForViewDto.Country
            };

            return PartialView("_ViewCountryModal", model);
        }

    }
}