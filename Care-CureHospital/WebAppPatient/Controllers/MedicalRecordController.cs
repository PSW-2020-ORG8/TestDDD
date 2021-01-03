using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.PatientDoctor;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;
using WebAppPatient.Validation;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        public MedicalRecordController() { }

        [HttpPost]      // POST /api/medicalRecord
        public IActionResult RegisterPatient(MedicalRecordDto dto)
        {
            MedicalRecordValidation medicalRecordValidation = new MedicalRecordValidation();
            if (!medicalRecordValidation.ValidateMedicalRecord(dto))
            {
                return BadRequest("The data which were entered are incorrect!");
            }
            App.Instance().MedicalRecordService.CreatePatientMedicalRecord(new MailAddress(dto.Patient.EMail), MedicalRecordMapper.MedicalRecordDtoToMedicalRecord(dto));
            App.Instance().MedicalRecordService.WritePatientProfilePictureInFile(dto.Patient.Username, dto.ProfilePicture);
            return Ok(200);
        }

        [HttpGet("getForPatient/{patientID}")]       // GET /api/medicalRecord/getForPatient/{id}
        public IActionResult GetMedicalRecordForPatient(int patientID) 
        {
            MedicalRecord medicalRecord = App.Instance().MedicalRecordService.GetMedicalRecordForPatient(patientID);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(MedicalRecordMapper.MedicalRecordToMedicalRecordDto(medicalRecord));
            }
        }

        [HttpGet("activatePatientMedicalRecord/{username}")]       // GET /api/medicalRecord/activatePatientMedicalRecord/{username}
        public IActionResult ActivatePatientMedicalRecord(string username)
        {
            MedicalRecord medicalRecord = App.Instance().MedicalRecordService.FindPatientMedicalRecordByUsername(username);
            if (medicalRecord == null)
            {
                return BadRequest();
            }
            App.Instance().MedicalRecordService.ActivatePatientMedicalRecord(medicalRecord.Id);
            return Redirect("http://localhost:51182/index.html#/");
        }
    }
}
