using Abp.Dependency;
using Abp.Domain.Entities.Caching;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using Experts.First_Project.Testing.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experts.First_Project.Testing
{
   public class TestEntityCache : EntityCache<TestEntity, TestEntityCacheItem>,ITestEntityCache, ITransientDependency
    {
        public TestEntityCache(ICacheManager cacheManager, IRepository<TestEntity> repository,IUnitOfWorkManager manager)
        : base(cacheManager, repository,manager,"MyTestEntityCache")
        {

        }

        protected override TestEntityCacheItem MapToCacheItem(TestEntity entity)
        {
            return ObjectMapper.Map<TestEntityCacheItem>(entity);
        }
    }
}
