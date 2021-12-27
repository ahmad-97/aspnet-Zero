using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Experts.First_Project.Testing.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Experts.First_Project.Testing
{
  public  interface ITestEntityAppService : IApplicationService
    {
        Task<List<TestEntityDto>> GetAll();
        Task<PagedResultDto<TestEntityForViewDto>> GetAllPaged(TestEntityInput input);
        Task Create(CreateTestEntityDto input);
        Task Add(CreateTestEntityDto input);
        Task Update(UpdateTestEntityDto input);
        //  Task Delete(int id);
        Task<TestEntityDto> GetById(int id);
        Task Delete(EntityDto input);
        Task<TestEntityCacheItem> GetCachedById(int id);
    }
}
