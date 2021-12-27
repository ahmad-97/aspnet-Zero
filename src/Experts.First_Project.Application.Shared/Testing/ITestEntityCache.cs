using Abp.Domain.Entities.Caching;
using Experts.First_Project.Testing.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Experts.First_Project.Testing
{
   public interface ITestEntityCache :IEntityCache<TestEntityCacheItem>
    {
    }
}
