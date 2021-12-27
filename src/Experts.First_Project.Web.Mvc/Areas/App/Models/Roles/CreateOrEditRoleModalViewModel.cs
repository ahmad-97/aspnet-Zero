using Abp.AutoMapper;
using Experts.First_Project.Authorization.Roles.Dto;
using Experts.First_Project.Web.Areas.App.Models.Common;

namespace Experts.First_Project.Web.Areas.App.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}