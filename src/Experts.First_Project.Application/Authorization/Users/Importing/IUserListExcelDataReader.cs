using System.Collections.Generic;
using Experts.First_Project.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Experts.First_Project.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
