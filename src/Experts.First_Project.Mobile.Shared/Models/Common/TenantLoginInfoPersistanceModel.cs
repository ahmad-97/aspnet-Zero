using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Experts.First_Project.Sessions.Dto;

namespace Experts.First_Project.Models.Common
{
    [AutoMapFrom(typeof(TenantLoginInfoDto)),
     AutoMapTo(typeof(TenantLoginInfoDto))]
    public class TenantLoginInfoPersistanceModel : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}