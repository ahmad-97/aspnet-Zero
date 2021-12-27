using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Experts.First_Project
{
    [DependsOn(typeof(First_ProjectCoreSharedModule))]
    public class First_ProjectApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(First_ProjectApplicationSharedModule).GetAssembly());
        }
    }
}