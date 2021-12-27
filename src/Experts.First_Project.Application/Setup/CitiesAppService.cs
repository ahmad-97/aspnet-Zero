using Experts.First_Project.Startup;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Experts.First_Project.Setup.Exporting;
using Experts.First_Project.Setup.Dtos;
using Experts.First_Project.Dto;
using Abp.Application.Services.Dto;
using Experts.First_Project.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using Experts.First_Project.Storage;

namespace Experts.First_Project.Setup
{
    [AbpAuthorize(AppPermissions.Pages_Cities)]
    public class CitiesAppService : First_ProjectAppServiceBase, ICitiesAppService
    {
        private readonly IRepository<City> _cityRepository;
        private readonly ICitiesExcelExporter _citiesExcelExporter;
        private readonly IRepository<Governatate, int> _lookup_governatateRepository;

        public CitiesAppService(IRepository<City> cityRepository, ICitiesExcelExporter citiesExcelExporter, IRepository<Governatate, int> lookup_governatateRepository)
        {
            _cityRepository = cityRepository;
            _citiesExcelExporter = citiesExcelExporter;
            _lookup_governatateRepository = lookup_governatateRepository;

        }

        public async Task<PagedResultDto<GetCityForViewDto>> GetAll(GetAllCitiesInput input)
        {

            var filteredCities = _cityRepository.GetAll()
                        .Include(e => e.GovernatateFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.GovernatateNameFilter), e => e.GovernatateFk != null && e.GovernatateFk.Name == input.GovernatateNameFilter);

            var pagedAndFilteredCities = filteredCities
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var cities = from o in pagedAndFilteredCities
                         join o1 in _lookup_governatateRepository.GetAll() on o.GovernatateId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new
                         {

                             o.Name,
                             Id = o.Id,
                             GovernatateName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                         };

            var totalCount = await filteredCities.CountAsync();

            var dbList = await cities.ToListAsync();
            var results = new List<GetCityForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetCityForViewDto()
                {
                    City = new CityDto
                    {

                        Name = o.Name,
                        Id = o.Id,
                    },
                    GovernatateName = o.GovernatateName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetCityForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetCityForViewDto> GetCityForView(int id)
        {
            var city = await _cityRepository.GetAsync(id);

            var output = new GetCityForViewDto { City = ObjectMapper.Map<CityDto>(city) };

            if (output.City.GovernatateId != null)
            {
                var _lookupGovernatate = await _lookup_governatateRepository.FirstOrDefaultAsync((int)output.City.GovernatateId);
                output.GovernatateName = _lookupGovernatate?.Name?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Cities_Edit)]
        public async Task<GetCityForEditOutput> GetCityForEdit(EntityDto input)
        {
            var city = await _cityRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetCityForEditOutput { City = ObjectMapper.Map<CreateOrEditCityDto>(city) };

            if (output.City.GovernatateId != null)
            {
                var _lookupGovernatate = await _lookup_governatateRepository.FirstOrDefaultAsync((int)output.City.GovernatateId);
                output.GovernatateName = _lookupGovernatate?.Name?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditCityDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Cities_Create)]
        protected virtual async Task Create(CreateOrEditCityDto input)
        {
            var city = ObjectMapper.Map<City>(input);

            if (AbpSession.TenantId != null)
            {
                city.TenantId = (int?)AbpSession.TenantId;
            }

            await _cityRepository.InsertAsync(city);

        }

        [AbpAuthorize(AppPermissions.Pages_Cities_Edit)]
        protected virtual async Task Update(CreateOrEditCityDto input)
        {
            var city = await _cityRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, city);

        }

        [AbpAuthorize(AppPermissions.Pages_Cities_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _cityRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetCitiesToExcel(GetAllCitiesForExcelInput input)
        {

            var filteredCities = _cityRepository.GetAll()
                        .Include(e => e.GovernatateFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.GovernatateNameFilter), e => e.GovernatateFk != null && e.GovernatateFk.Name == input.GovernatateNameFilter);

            var query = (from o in filteredCities
                         join o1 in _lookup_governatateRepository.GetAll() on o.GovernatateId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetCityForViewDto()
                         {
                             City = new CityDto
                             {
                                 Name = o.Name,
                                 Id = o.Id
                             },
                             GovernatateName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                         });

            var cityListDtos = await query.ToListAsync();

            return _citiesExcelExporter.ExportToFile(cityListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_Cities)]
        public async Task<PagedResultDto<CityGovernatateLookupTableDto>> GetAllGovernatateForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_governatateRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Name != null && e.Name.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var governatateList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<CityGovernatateLookupTableDto>();
            foreach (var governatate in governatateList)
            {
                lookupTableDtoList.Add(new CityGovernatateLookupTableDto
                {
                    Id = governatate.Id,
                    DisplayName = governatate.Name?.ToString()
                });
            }

            return new PagedResultDto<CityGovernatateLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }

    }
}