using Abp.Domain.Services;

namespace Experts.First_Project
{
    public abstract class First_ProjectDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected First_ProjectDomainServiceBase()
        {
            LocalizationSourceName = First_ProjectConsts.LocalizationSourceName;
        }
    }
}
