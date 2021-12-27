using System.Linq;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Experts.First_Project.Authorization.Users.Dto;
using Experts.First_Project.Security;
using Experts.First_Project.Web.Areas.App.Models.Common;

namespace Experts.First_Project.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserForEditOutput))]
    public class CreateOrEditUserModalViewModel : GetUserForEditOutput, IOrganizationUnitsEditViewModel
    {
        public bool CanChangeUserName => User.UserName != AbpUserBase.AdminUserName;

        public int AssignedRoleCount
        {
            get { return Roles.Count(r => r.IsAssigned); }
        }

        public bool IsEditMode => User.Id.HasValue;

        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }
    }
}