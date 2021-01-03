using System.Collections.Generic;
using System.Linq;
using Backend;
using Microsoft.AspNetCore.Mvc;
using IntegrationAdapters.Dto;
using IntegrationAdapters.Mapper;
using Backend.Model.DoctorMenager;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController:ControllerBase
    {
        public ReportController() { }
        
        [HttpGet]   //GET /api/report
        public IActionResult GetAllReports()
        {
            List<ReportDto> result = new List<ReportDto>();
            App.Instance().ReportService.GetAllEntities().ToList().ForEach(report => result.Add(ReportMapper.ReportToReportDto(report)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddReport(ReportDto dto)
        {
            Report report = ReportMapper.ReportDtoToReport(dto);
            App.Instance().ReportService.AddEntity(report);
            return Ok();
        }

        [HttpPost("send")]
        public IActionResult SendReport()
        {
            App.Instance().ReportService.SendReportSftp();
            return Ok();
        }
    }
}
