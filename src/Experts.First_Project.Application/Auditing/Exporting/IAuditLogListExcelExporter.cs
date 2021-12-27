using System.Collections.Generic;
using Experts.First_Project.Auditing.Dto;
using Experts.First_Project.Dto;

namespace Experts.First_Project.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
