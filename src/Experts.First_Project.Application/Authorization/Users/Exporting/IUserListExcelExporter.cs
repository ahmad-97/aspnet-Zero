using System.Collections.Generic;
using Experts.First_Project.Authorization.Users.Dto;
using Experts.First_Project.Dto;

namespace Experts.First_Project.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}