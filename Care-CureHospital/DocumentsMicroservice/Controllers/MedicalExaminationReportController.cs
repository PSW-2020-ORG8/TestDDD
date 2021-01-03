using DocumentsMicroservice.Dto;
using DocumentsMicroservice.Mapper;
using DocumentsMicroservice.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExaminationReportController : ControllerBase
    {
        private IMedicalExaminationReportService medicalExaminationReportService;

        public MedicalExaminationReportController(IMedicalExaminationReportService medicalExaminationReportService) 
        {
            this.medicalExaminationReportService = medicalExaminationReportService;
        }

        [HttpGet]       // GET /api/medicalExaminationReport
        public IActionResult GetAllMedicalExaminationReports()
        {
            List<MedicalExaminationReportDto> result = new List<MedicalExaminationReportDto>();
            this.medicalExaminationReportService.GetAllEntities().ToList().ForEach(medicalExaminationReport => result.Add(MedicalExaminationReportMapper.MedicalExaminationReportToMedicalExaminationReportDto(medicalExaminationReport)));
            return Ok(result);
        }

        [HttpGet("getForPatient/{patientID}")]       // GET /api/medicalExaminationReport/getForPatient/{id}
        public IActionResult GetMedicalExaminationReportsForPatient(int patientID)
        {
            List<MedicalExaminationReportDto> result = new List<MedicalExaminationReportDto>();
            this.medicalExaminationReportService.GetMedicalExaminationReportsForPatient(patientID).ToList().ForEach(
                medicalExaminationReport => result.Add(MedicalExaminationReportMapper.MedicalExaminationReportToMedicalExaminationReportDto(medicalExaminationReport)));
            return Ok(result);
        }

        [HttpGet("findReportsByDoctor")]       // GET /api/medicalExaminationReport/findReportsByDoctor
        public IActionResult FindMedicalExaminationReportsByDoctor([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "doctor")] string doctor)
        {
            List<MedicalExaminationReportDto> result = new List<MedicalExaminationReportDto>();
            this.medicalExaminationReportService.FindReportsForDoctorParameter(patientId, doctor).ToList().ForEach(medicalExaminationReport => result.Add(MedicalExaminationReportMapper.MedicalExaminationReportToMedicalExaminationReportDto(medicalExaminationReport)));
            return Ok(result);
        }

        [HttpGet("findReportsByDate")]       // GET /api/medicalExaminationReport/findReportsByDate
        public IActionResult FindMedicalExaminationReportsByDate([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "date")] string date)
        {
            List<MedicalExaminationReportDto> result = new List<MedicalExaminationReportDto>();
            this.medicalExaminationReportService.FindReportsForDateParameter(patientId, date).ToList().ForEach(medicalExaminationReport => result.Add(MedicalExaminationReportMapper.MedicalExaminationReportToMedicalExaminationReportDto(medicalExaminationReport)));
            return Ok(result);
        }

        [HttpGet("findReportsByComment")]       // GET /api/medicalExaminationReport/findReportsByComment
        public IActionResult FindMedicalExaminationReportsByComment([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "comment")] string comment)
        {
            List<MedicalExaminationReportDto> result = new List<MedicalExaminationReportDto>();
            this.medicalExaminationReportService.FindReportsForCommentParameter(patientId, comment).ToList().ForEach(medicalExaminationReport => result.Add(MedicalExaminationReportMapper.MedicalExaminationReportToMedicalExaminationReportDto(medicalExaminationReport)));
            return Ok(result);
        }

        [HttpGet("findReportsByRoom")]       // GET /api/medicalExaminationReport/findReportsByRoom
        public IActionResult FindMedicalExaminationReportsByRoom([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "room")] string room)
        {
            List<MedicalExaminationReportDto> result = new List<MedicalExaminationReportDto>();
            this.medicalExaminationReportService.FindReportsForRoomParameter(patientId, room).ToList().ForEach(medicalExaminationReport => result.Add(MedicalExaminationReportMapper.MedicalExaminationReportToMedicalExaminationReportDto(medicalExaminationReport)));
            return Ok(result);
        }

        [HttpPost("advancedSearchReportsForPatient")]       // POST /api/medicalExaminationReport/advancedSearchReportsForPatient  
        public IActionResult FindMedicalExaminationReportsForPatient(MedicalExaminationReportDto dto)
        {
            List<MedicalExaminationReportDto> result = new List<MedicalExaminationReportDto>();
            this.medicalExaminationReportService.FindReportsUsingAdvancedSearch(dto.PatientId, dto.SearchParams, dto.LogicOperators).ToList().ForEach(medicalExaminationReport => result.Add(MedicalExaminationReportMapper.MedicalExaminationReportToMedicalExaminationReportDto(medicalExaminationReport)));
            return Ok(result);
        }

        [HttpGet("simpleSearchReportsForPatient")]       // GET /api/medicalExaminationReport/simpleSearchReportsForPatient  
        public IActionResult FindMedicalExaminationReportsForPatientUsingSimpleSearch([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "doctor")] string doctor, [FromQuery(Name = "date")] string date, [FromQuery(Name = "comment")] string comment, [FromQuery(Name = "room")] string room)
        {
            List<MedicalExaminationReportDto> result = new List<MedicalExaminationReportDto>();
            this.medicalExaminationReportService.FindReportsUsingSimpleSearch(patientId, doctor, date, comment, room).ToList().ForEach(medicalExaminationReport => result.Add(MedicalExaminationReportMapper.MedicalExaminationReportToMedicalExaminationReportDto(medicalExaminationReport)));
            return Ok(result);
        }
    }
}
