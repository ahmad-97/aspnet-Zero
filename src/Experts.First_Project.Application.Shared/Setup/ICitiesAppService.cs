using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Experts.First_Project.Setup.Dtos;
using Experts.First_Project.Dto;

namespace Experts.First_Project.Setup
{
    public interface ICitiesAppService : IApplicationService
    {
        Task<PagedResultDto<GetCityForViewDto>> GetAll(GetAllCitiesInput input);

        Task<GetCityForViewDto> GetCityForView(int id);

        Task<GetCityForEditOutput> GetCityForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditCityDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetCitiesToExcel(GetAllCitiesForExcelInput input);

        Task<PagedResultDto<CityGovernatateLookupTableDto>> GetAllGovernatateForLookupTable(GetAllForLookupTableInput input);

    }
}