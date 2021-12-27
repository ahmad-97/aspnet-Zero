using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Experts.First_Project.DataExporting.Excel.NPOI;
using Experts.First_Project.Setup.Dtos;
using Experts.First_Project.Dto;
using Experts.First_Project.Storage;

namespace Experts.First_Project.Setup.Exporting
{
    public class CitiesExcelExporter : NpoiExcelExporterBase, ICitiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CitiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetCityForViewDto> cities)
        {
            return CreateExcelPackage(
                "Cities.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Cities"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        (L("Governatate")) + L("Name")
                        );

                    AddObjects(
                        sheet, cities,
                        _ => _.City.Name,
                        _ => _.GovernatateName
                        );

                });
        }
    }
}