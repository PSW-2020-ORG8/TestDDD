using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        public PatientController() { }

        [HttpGet()]       // GET /api/patient
        public IActionResult GetAllPatients(int patientId)
        {
            List<PatientDto> result = new List<PatientDto>();
            App.Instance().PatientService.GetAllEntities().ToList().ForEach(patient => result.Add(PatientMapper.PatientToPatientDto(patient,
                App.Instance().AppointmentService.CountCancelledAppointmentsForPatient(patient.Id, DateTime.Now))));
            return Ok(result);
        }

        [HttpGet("getMaliciousPatients")]       // GET /api/patient/getMaliciousPatients
        public IActionResult GetMaliciousPatients()
        {
            List<PatientDto> result = new List<PatientDto>();
            App.Instance().PatientService.GetMaliciousPatients().ToList().ForEach(patient => result.Add(PatientMapper.PatientToPatientDto(patient, 
                App.Instance().AppointmentService.CountCancelledAppointmentsForPatient(patient.Id, DateTime.Now))));
            return Ok(result);
        }

        [HttpPut("blockMaliciousPatient/{patientId}")]       // GET /api/patient/blockMaliciousPatient/{patientId}
        public IActionResult BlockMaliciousPatient(int patientId)
        {
            return Ok(App.Instance().PatientService.BlockMaliciousPatient(patientId));
        }
    }
}
