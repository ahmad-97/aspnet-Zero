using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Experts.First_Project.Startup
{
    [DependsOn(typeof(First_ProjectCoreModule))]
    public class First_ProjectGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(First_ProjectGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}