using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Experts.First_Project.Web.Areas.App.Models.Governatates;
using Experts.First_Project.Web.Controllers;
using Experts.First_Project.Authorization;
using Experts.First_Project.Startup;
using Experts.First_Project.Startup.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace Experts.First_Project.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Governatates)]
    public class GovernatatesController : First_ProjectControllerBase
    {
        private readonly IGovernatatesAppService _governatatesAppService;

        public GovernatatesController(IGovernatatesAppService governatatesAppService)
        {
            _governatatesAppService = governatatesAppService;

        }

        public ActionResult Index()
        {
            var model = new GovernatatesViewModel
            {
                FilterText = ""
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Governatates_Create, AppPermissions.Pages_Governatates_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetGovernatateForEditOutput getGovernatateForEditOutput;

            if (id.HasValue)
            {
                getGovernatateForEditOutput = await _governatatesAppService.GetGovernatateForEdit(new EntityDto { Id = (int)id });
            }
            else
            {
                getGovernatateForEditOutput = new GetGovernatateForEditOutput
                {
                    Governatate = new CreateOrEditGovernatateDto()
                };
            }

            var viewModel = new CreateOrEditGovernatateModalViewModel()
            {
                Governatate = getGovernatateForEditOutput.Governatate,

            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> ViewGovernatateModal(int id)
        {
            var getGovernatateForViewDto = await _governatatesAppService.GetGovernatateForView(id);

            var model = new GovernatateViewModel()
            {
                Governatate = getGovernatateForViewDto.Governatate
            };

            return PartialView("_ViewGovernatateModal", model);
        }

    }
}