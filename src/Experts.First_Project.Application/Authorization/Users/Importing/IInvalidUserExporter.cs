using System.Collections.Generic;
using Experts.First_Project.Authorization.Users.Importing.Dto;
using Experts.First_Project.Dto;

namespace Experts.First_Project.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
