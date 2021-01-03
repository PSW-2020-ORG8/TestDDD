using Backend.Model.DoctorMenager;
using Backend.Repository.DirectorRepository;
using Backend.Service.DirectorService;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.IntegrationAdaptersUnitTests
{
    public class ReportTest
    {
        [Fact]
        public void Get_reports()
        {
            ReportService reportService = new ReportService(CreateStubRepository());

            List<Report> results = (List<Report>)reportService.GetAllEntities();

            Assert.NotNull(results);
        }

        [Fact]
        public void Add_report()
        {
            ReportService reportService = new ReportService(CreateStubRepository());

            Report report = reportService.AddEntity(new Report(1, 3, "Paracetamol", 10, new DateTime(2020, 1, 6, 8, 30, 0), new DateTime(2020, 12, 6, 8, 30, 0)));

            Assert.NotNull(report);
        }

        [Fact]
        public void Find_medicament_for_the_certain_period()
        {
            ReportService reportService = new ReportService(CreateStubRepository());

            List<Report> reports = (List<Report>)reportService.GetReportForCertainPeriod(new DateTime(2019, 11, 6, 8, 30, 0), new DateTime(2019, 12, 6, 8, 30, 0));

            Assert.NotEmpty(reports);

        }

        [Fact]
        public void Not_found_medicament_for_the_certain_period()
        {
            ReportService reportService = new ReportService(CreateStubRepository());

            List<Report> reports = (List<Report>)reportService.GetReportForCertainPeriod(new DateTime(2018, 11, 6, 8, 30, 0), new DateTime(2018, 12, 6, 8, 30, 0));

            Assert.Empty(reports);

        }

        private static IReportRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IReportRepository>();
            var reports = new List<Report>();

            reports.Add(new Report(1, 1, "Brufen", 12, new DateTime(2019, 11, 6, 8, 30, 0), new DateTime(2019, 12, 6, 8, 30, 0)));
            reports.Add(new Report(2, 5, "Vitamin C", 102, new DateTime(2020, 5, 6, 8, 30, 0), new DateTime(2020, 11, 6, 8, 30, 0)));
            reports.Add(new Report(3, 4, "Paracetamol", 10, new DateTime(2020, 1, 6, 8, 30, 0), new DateTime(2020, 12, 6, 8, 30, 0)));

            stubRepository.Setup(reportRepository => reportRepository.GetAllEntities()).Returns(reports);
            stubRepository.Setup(report => report.AddEntity(It.IsAny<Report>())).Returns(new Report(1, 1, "Brufen", 12, new DateTime(2019, 11, 6, 8, 30, 0), new DateTime(2019, 12, 6, 8, 30, 0)));

            return stubRepository.Object;
        }
    }
}
