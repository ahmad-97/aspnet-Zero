using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Experts.First_Project.Authorization.Users;
using Experts.First_Project.MultiTenancy;

namespace Experts.First_Project.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}