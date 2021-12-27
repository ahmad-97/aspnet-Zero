using Abp;

namespace Experts.First_Project
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="First_ProjectDomainServiceBase"/>.
    /// For application services inherit First_ProjectAppServiceBase.
    /// </summary>
    public abstract class First_ProjectServiceBase : AbpServiceBase
    {
        protected First_ProjectServiceBase()
        {
            LocalizationSourceName = First_ProjectConsts.LocalizationSourceName;
        }
    }
}