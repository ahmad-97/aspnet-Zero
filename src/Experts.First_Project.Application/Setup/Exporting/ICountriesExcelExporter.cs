using System.Collections.Generic;
using Experts.First_Project.Setup.Dtos;
using Experts.First_Project.Dto;

namespace Experts.First_Project.Setup.Exporting
{
    public interface ICountriesExcelExporter
    {
        FileDto ExportToFile(List<GetCountryForViewDto> countries);
    }
}