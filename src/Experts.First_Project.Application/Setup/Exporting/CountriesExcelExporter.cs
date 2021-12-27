using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Experts.First_Project.DataExporting.Excel.NPOI;
using Experts.First_Project.Setup.Dtos;
using Experts.First_Project.Dto;
using Experts.First_Project.Storage;

namespace Experts.First_Project.Setup.Exporting
{
    public class CountriesExcelExporter : NpoiExcelExporterBase, ICountriesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CountriesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetCountryForViewDto> countries)
        {
            return CreateExcelPackage(
                "Countries.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Countries"));

                    AddHeader(
                        sheet,
                        L("Code"),
                        L("Desc")
                        );

                    AddObjects(
                        sheet,  countries,
                        _ => _.Country.Code,
                        _ => _.Country.Desc
                        );

                });
        }
    }
}