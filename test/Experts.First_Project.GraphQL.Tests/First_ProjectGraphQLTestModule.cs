using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Experts.First_Project.Configure;
using Experts.First_Project.Startup;
using Experts.First_Project.Test.Base;

namespace Experts.First_Project.GraphQL.Tests
{
    [DependsOn(
        typeof(First_ProjectGraphQLModule),
        typeof(First_ProjectTestBaseModule))]
    public class First_ProjectGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(First_ProjectGraphQLTestModule).GetAssembly());
        }
    }
}