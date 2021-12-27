using System.Collections.Generic;
using Abp;
using Experts.First_Project.Chat.Dto;
using Experts.First_Project.Dto;

namespace Experts.First_Project.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
