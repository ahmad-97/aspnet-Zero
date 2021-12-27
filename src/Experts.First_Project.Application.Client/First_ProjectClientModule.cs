using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Experts.First_Project
{
    public class First_ProjectClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(First_ProjectClientModule).GetAssembly());
        }
    }
}
