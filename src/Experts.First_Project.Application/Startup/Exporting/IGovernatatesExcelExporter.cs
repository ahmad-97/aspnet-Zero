using System.Collections.Generic;
using Experts.First_Project.Startup.Dtos;
using Experts.First_Project.Dto;

namespace Experts.First_Project.Startup.Exporting
{
    public interface IGovernatatesExcelExporter
    {
        FileDto ExportToFile(List<GetGovernatateForViewDto> governatates);
    }
}