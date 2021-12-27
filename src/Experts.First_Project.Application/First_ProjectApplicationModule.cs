using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Experts.First_Project.Authorization;
using System;

namespace Experts.First_Project
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(First_ProjectApplicationSharedModule),
        typeof(First_ProjectCoreModule)
        )]
    public class First_ProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();
            //all chaching
            Configuration.Caching.ConfigureAll(caching =>
            {
                caching.DefaultSlidingExpireTime = TimeSpan.FromMinutes(90);
            });
            //specific chaching group
            Configuration.Caching.Configure("MyCache", caching =>
            {
                caching.DefaultSlidingExpireTime = TimeSpan.FromMinutes(30);
            });
            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(First_ProjectApplicationModule).GetAssembly());
        }
    }
}