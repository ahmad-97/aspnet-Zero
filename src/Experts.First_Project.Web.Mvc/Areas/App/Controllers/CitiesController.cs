using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Experts.First_Project.Web.Areas.App.Models.Cities;
using Experts.First_Project.Web.Controllers;
using Experts.First_Project.Authorization;
using Experts.First_Project.Setup;
using Experts.First_Project.Setup.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace Experts.First_Project.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Cities)]
    public class CitiesController : First_ProjectControllerBase
    {
        private readonly ICitiesAppService _citiesAppService;

        public CitiesController(ICitiesAppService citiesAppService)
        {
            _citiesAppService = citiesAppService;

        }

        public ActionResult Index()
        {
            var model = new CitiesViewModel
            {
                FilterText = ""
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Cities_Create, AppPermissions.Pages_Cities_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetCityForEditOutput getCityForEditOutput;

            if (id.HasValue)
            {
                getCityForEditOutput = await _citiesAppService.GetCityForEdit(new EntityDto { Id = (int)id });
            }
            else
            {
                getCityForEditOutput = new GetCityForEditOutput
                {
                    City = new CreateOrEditCityDto()
                };
            }

            var viewModel = new CreateOrEditCityModalViewModel()
            {
                City = getCityForEditOutput.City,
                GovernatateName = getCityForEditOutput.GovernatateName,

            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> ViewCityModal(int id)
        {
            var getCityForViewDto = await _citiesAppService.GetCityForView(id);

            var model = new CityViewModel()
            {
                City = getCityForViewDto.City
                ,
                GovernatateName = getCityForViewDto.GovernatateName

            };

            return PartialView("_ViewCityModal", model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Cities_Create, AppPermissions.Pages_Cities_Edit)]
        public PartialViewResult GovernatateLookupTableModal(int? id, string displayName)
        {
            var viewModel = new CityGovernatateLookupTableViewModel()
            {
                Id = id,
                DisplayName = displayName,
                FilterText = ""
            };

            return PartialView("_CityGovernatateLookupTableModal", viewModel);
        }

    }
}