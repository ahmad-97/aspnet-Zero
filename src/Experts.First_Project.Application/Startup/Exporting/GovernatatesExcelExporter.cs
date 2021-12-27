using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Experts.First_Project.DataExporting.Excel.NPOI;
using Experts.First_Project.Startup.Dtos;
using Experts.First_Project.Dto;
using Experts.First_Project.Storage;

namespace Experts.First_Project.Startup.Exporting
{
    public class GovernatatesExcelExporter : NpoiExcelExporterBase, IGovernatatesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public GovernatatesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetGovernatateForViewDto> governatates)
        {
            return CreateExcelPackage(
                "Governatates.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Governatates"));

                    AddHeader(
                        sheet,
                        L("code"),
                        L("Name")
                        );

                    AddObjects(
                        sheet, governatates,
                        _ => _.Governatate.code,
                        _ => _.Governatate.Name
                        );

                });
        }
    }
}