using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Experts.First_Project
{
    [DependsOn(typeof(First_ProjectXamarinSharedModule))]
    public class First_ProjectXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(First_ProjectXamarinIosModule).GetAssembly());
        }
    }
}