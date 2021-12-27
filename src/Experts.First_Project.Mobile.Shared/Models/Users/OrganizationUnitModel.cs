using Abp.AutoMapper;
using Experts.First_Project.Organizations.Dto;

namespace Experts.First_Project.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}