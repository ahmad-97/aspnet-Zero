using Abp.AutoMapper;
using Experts.First_Project.Authorization.Users;
using Experts.First_Project.Authorization.Users.Dto;
using Experts.First_Project.Web.Areas.App.Models.Common;

namespace Experts.First_Project.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}