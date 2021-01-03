using IntegrationAdapters.Dto;
using Backend.Model.DoctorMenager;
using System;

namespace IntegrationAdapters.Mapper
{
    public class ReportMapper
    {
        public static ReportDto ReportToReportDto(Report report)
        {
            ReportDto dto = new ReportDto();
            dto.Id = report.Id;
            dto.MedicamentName = report.MedicamentName;
            dto.Quantity = report.Quantity;
            dto.FromDate = report.FromDate.ToString("dd.MM.yyyy. HH:mm");
            dto.ToDate = report.ToDate.ToString("dd.MM.yyyy. HH:mm");
            return dto;
        }

        public static Report ReportDtoToReport(ReportDto dto)
        {
            Report report = new Report();

            report.Id = dto.Id;
            report.MedicamentId = dto.MedicamentId;
            report.MedicamentName = dto.MedicamentName;
            report.Quantity = dto.Quantity;
            report.FromDate = DateTime.Today;
            report.ToDate = DateTime.Now;

            return report;
        }
    }
}
