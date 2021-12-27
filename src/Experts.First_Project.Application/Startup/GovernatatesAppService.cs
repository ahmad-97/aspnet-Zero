using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Experts.First_Project.Startup.Exporting;
using Experts.First_Project.Startup.Dtos;
using Experts.First_Project.Dto;
using Abp.Application.Services.Dto;
using Experts.First_Project.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using Experts.First_Project.Storage;

namespace Experts.First_Project.Startup
{
    [AbpAuthorize(AppPermissions.Pages_Governatates)]
    public class GovernatatesAppService : First_ProjectAppServiceBase, IGovernatatesAppService
    {
        private readonly IRepository<Governatate> _governatateRepository;
        private readonly IGovernatatesExcelExporter _governatatesExcelExporter;

        public GovernatatesAppService(IRepository<Governatate> governatateRepository, IGovernatatesExcelExporter governatatesExcelExporter)
        {
            _governatateRepository = governatateRepository;
            _governatatesExcelExporter = governatatesExcelExporter;

        }

        public async Task<PagedResultDto<GetGovernatateForViewDto>> GetAll(GetAllGovernatatesInput input)
        {

            var filteredGovernatates = _governatateRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.code.Contains(input.Filter) || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.codeFilter), e => e.code == input.codeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var pagedAndFilteredGovernatates = filteredGovernatates
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var governatates = from o in pagedAndFilteredGovernatates
                               select new
                               {

                                   o.code,
                                   o.Name,
                                   Id = o.Id
                               };

            var totalCount = await filteredGovernatates.CountAsync();

            var dbList = await governatates.ToListAsync();
            var results = new List<GetGovernatateForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetGovernatateForViewDto()
                {
                    Governatate = new GovernatateDto
                    {

                        code = o.code,
                        Name = o.Name,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetGovernatateForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetGovernatateForViewDto> GetGovernatateForView(int id)
        {
            var governatate = await _governatateRepository.GetAsync(id);

            var output = new GetGovernatateForViewDto { Governatate = ObjectMapper.Map<GovernatateDto>(governatate) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Governatates_Edit)]
        public async Task<GetGovernatateForEditOutput> GetGovernatateForEdit(EntityDto input)
        {
            var governatate = await _governatateRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetGovernatateForEditOutput { Governatate = ObjectMapper.Map<CreateOrEditGovernatateDto>(governatate) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditGovernatateDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Governatates_Create)]
        protected virtual async Task Create(CreateOrEditGovernatateDto input)
        {
            var governatate = ObjectMapper.Map<Governatate>(input);

            if (AbpSession.TenantId != null)
            {
                governatate.TenantId = (int?)AbpSession.TenantId;
            }

            await _governatateRepository.InsertAsync(governatate);

        }

        [AbpAuthorize(AppPermissions.Pages_Governatates_Edit)]
        protected virtual async Task Update(CreateOrEditGovernatateDto input)
        {
            var governatate = await _governatateRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, governatate);

        }

        [AbpAuthorize(AppPermissions.Pages_Governatates_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _governatateRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetGovernatatesToExcel(GetAllGovernatatesForExcelInput input)
        {

            var filteredGovernatates = _governatateRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.code.Contains(input.Filter) || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.codeFilter), e => e.code == input.codeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var query = (from o in filteredGovernatates
                         select new GetGovernatateForViewDto()
                         {
                             Governatate = new GovernatateDto
                             {
                                 code = o.code,
                                 Name = o.Name,
                                 Id = o.Id
                             }
                         });

            var governatateListDtos = await query.ToListAsync();

            return _governatatesExcelExporter.ExportToFile(governatateListDtos);
        }

    }
}