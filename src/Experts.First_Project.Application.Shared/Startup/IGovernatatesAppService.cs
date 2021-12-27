using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Experts.First_Project.Startup.Dtos;
using Experts.First_Project.Dto;

namespace Experts.First_Project.Startup
{
    public interface IGovernatatesAppService : IApplicationService
    {
        Task<PagedResultDto<GetGovernatateForViewDto>> GetAll(GetAllGovernatatesInput input);

        Task<GetGovernatateForViewDto> GetGovernatateForView(int id);

        Task<GetGovernatateForEditOutput> GetGovernatateForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditGovernatateDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetGovernatatesToExcel(GetAllGovernatatesForExcelInput input);

    }
}