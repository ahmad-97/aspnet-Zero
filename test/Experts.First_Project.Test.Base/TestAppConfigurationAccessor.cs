using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using Experts.First_Project.Configuration;

namespace Experts.First_Project.Test.Base
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(First_ProjectTestBaseModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}
