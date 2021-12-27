using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Organizations;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Experts.First_Project.Authorization;
using Experts.First_Project.Core.Base;
using Experts.First_Project.Core.Extensions;
using Experts.First_Project.Dto;
using Experts.First_Project.Types;

namespace Experts.First_Project.Queries
{
    public class OrganizationUnitQuery : First_ProjectQueryBase<ListGraphType<OrganizationUnitType>, List<OrganizationUnitDto>>
    {
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;

        public static class Args
        {
            public const string Id = "id";
            public const string TenantId = "tenantId";
            public const string Code = "code";
        }

        public OrganizationUnitQuery(IRepository<OrganizationUnit, long> organizationUnitRepository)
            : base("organizationUnits", new Dictionary<string, Type>
            {
                {Args.Id, typeof(IdGraphType)},
                {Args.TenantId, typeof(IntGraphType)},
                {Args.Code, typeof(StringGraphType)}
            })
        {
            _organizationUnitRepository = organizationUnitRepository;
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits)]
        public override async Task<List<OrganizationUnitDto>> Resolve(IResolveFieldContext context)
        {
            var query = _organizationUnitRepository.GetAll().AsNoTracking();

            context
                .ContainsArgument<long>(Args.Id, id => query = query.Where(o => o.Id == id))
                .ContainsArgument<int?>(Args.TenantId, tenantId => query = query.Where(o => o.TenantId == tenantId.Value))
                .ContainsArgument<string>(Args.Code, code => query = query.Where(o => o.Code == code));

            return await ProjectToListAsync<OrganizationUnitDto>(query);
        }
    }
}
