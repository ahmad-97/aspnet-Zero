using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Experts.First_Project
{
    [DependsOn(typeof(First_ProjectXamarinSharedModule))]
    public class First_ProjectXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(First_ProjectXamarinAndroidModule).GetAssembly());
        }
    }
}