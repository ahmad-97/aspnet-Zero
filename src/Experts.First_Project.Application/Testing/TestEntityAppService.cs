using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.UI;
using Experts.First_Project.Testing.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Mvc;
using Abp.Auditing;
using Abp.Authorization;
using Experts.First_Project.Authorization;
using Abp.Runtime.Caching;

namespace Experts.First_Project.Testing
{
    [AbpAuthorize(AppPermissions.Pages_TestEntities)]
    public class TestEntityAppService : First_ProjectAppServiceBase, ITestEntityAppService
    {
        private readonly IRepository<TestEntity> _testEntityRepository;
        private readonly ICacheManager _cacheManager;
        private readonly ITestEntityCache _testEntityCache;
        public TestEntityAppService(IRepository<TestEntity> testEntityRepository, ICacheManager cacheManager, ITestEntityCache testEntityCache)
        {
            _testEntityRepository = testEntityRepository;
            _cacheManager = cacheManager;
            _testEntityCache = testEntityCache;
        }

        [HttpGet]
        public async Task Add(CreateTestEntityDto input)
        {
            var testEntity = ObjectMapper.Map<TestEntity>(input);
            await _testEntityRepository.InsertAsync(testEntity);
        }

        [AbpAuthorize(AppPermissions.Pages_TestEntities_Create)]
        public async Task Create(CreateTestEntityDto input)
        {
            var testEntity = ObjectMapper.Map<TestEntity>(input);
            await _testEntityRepository.InsertAsync(testEntity);
        }

        [AbpAuthorize(AppPermissions.Pages_TestEntities_Delete)]
        public async Task Delete(EntityDto input)
        {
            _testEntityRepository.DeleteAsync(input.Id);
        }
        [DisableAuditing]
        [AbpAuthorize(AppPermissions.Pages_TestEntities)]

        public async Task<List<TestEntityDto>> GetAll()
        {
            // throw new UserFriendlyException(L("Ooppps! There is a problem!"), L("You are trying to see a product that is deleted..."));
            return await _cacheManager.GetCache(MyCachingKeys.MyTestEntityCache).
                 GetAsync("all", async (itemId) =>
                 {
                     var lst = await _testEntityRepository.GetAll().ToListAsync();
                     return ObjectMapper.Map<List<TestEntityDto>>(lst);
                 }) as List<TestEntityDto>;

            //var lst = await _testEntityRepository.GetAll().ToListAsync();
            //return ObjectMapper.Map<List<TestEntityDto>>(lst);
        }

        [AbpAuthorize(AppPermissions.Pages_TestEntities)]
        public async Task<PagedResultDto<TestEntityForViewDto>> GetAllPaged(TestEntityInput input)
        {
            var data = _testEntityRepository.GetAll()
                 .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => e.Description.Contains(input.Filter));

            var pagedData = data.OrderBy(input.Sorting ?? "description asc").PageBy(input);

            int totalRecords = await data.CountAsync();
            var lst = await pagedData.ToListAsync();
            var output = new PagedResultDto<TestEntityForViewDto>(totalRecords, ObjectMapper.Map<List<TestEntityForViewDto>>(lst));
            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_TestEntities_Update)]
        public async Task Update(UpdateTestEntityDto input)
        {
            var currentObj = await _testEntityRepository.GetAsync(input.Id);
            if (currentObj == null)
            {
                throw new UserFriendlyException("This object dosen't exists");
            }
            ObjectMapper.Map(input, currentObj);
        }

        public async Task<TestEntityDto> GetById(int id)
        {
            var output = await _cacheManager.GetCache<int, TestEntityDto>(MyCachingKeys.MyTestEntityCache).GetAsync(id, async (id) =>
            {
                var obj = _testEntityRepository.Get(id);
                if (obj == null)
                    return null;
                return ObjectMapper.Map<TestEntityDto>(obj);
            });
            return output;
        }

        public async Task<TestEntityCacheItem> GetCachedById(int id)
        {
            return await _testEntityCache.GetAsync(id);
        }
    }
}
