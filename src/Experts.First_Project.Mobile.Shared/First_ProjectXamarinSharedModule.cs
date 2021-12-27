using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Experts.First_Project
{
    [DependsOn(typeof(First_ProjectClientModule), typeof(AbpAutoMapperModule))]
    public class First_ProjectXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(First_ProjectXamarinSharedModule).GetAssembly());
        }
    }
}