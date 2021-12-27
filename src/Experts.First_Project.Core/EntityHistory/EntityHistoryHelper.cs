using Experts.First_Project.Setup;
using System;
using System.Linq;
using Abp.Organizations;
using Experts.First_Project.Authorization.Roles;
using Experts.First_Project.MultiTenancy;
using Experts.First_Project.Testing;

namespace Experts.First_Project.EntityHistory
{
    public static class EntityHistoryHelper
    {
        public const string EntityHistoryConfigurationName = "EntityHistory";

        public static readonly Type[] HostSideTrackedTypes =
        {
            typeof(Country),
            typeof(TestEntity),
            typeof(OrganizationUnit), typeof(Role), typeof(Tenant)
        };

        public static readonly Type[] TenantSideTrackedTypes =
        {
            typeof(Country),
            typeof(OrganizationUnit), typeof(Role),typeof(TestEntity)
        };

        public static readonly Type[] TrackedTypes =
            HostSideTrackedTypes
                .Concat(TenantSideTrackedTypes)
                .GroupBy(type => type.FullName)
                .Select(types => types.First())
                .ToArray();
    }
}