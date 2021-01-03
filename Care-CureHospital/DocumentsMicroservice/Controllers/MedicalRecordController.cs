using DocumentsMicroservice.Dto;
using DocumentsMicroservice.Mapper;
using DocumentsMicroservice.Service;
using DocumentsMicroservice.Validation;
using Microsoft.AspNetCore.Mvc;
using Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private IMedicalRecordService medicalRecordService;
        private IPatientService patientService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService, IPatientService patientService) 
        {
            this.medicalRecordService = medicalRecordService;
            this.patientService = patientService;
        }

        [HttpPost]      // POST /api/medicalRecord
        public IActionResult RegisterPatient(MedicalRecordDto dto)
        {
            MedicalRecordValidation medicalRecordValidation = new MedicalRecordValidation(this.patientService);
            if (!medicalRecordValidation.ValidateMedicalRecord(dto))
            {
                return BadRequest("The data which were entered are incorrect!");
            }
            this.medicalRecordService.CreatePatientMedicalRecord(new MailAddress(dto.Patient.EMail), MedicalRecordMapper.MedicalRecordDtoToMedicalRecord(dto));
            this.medicalRecordService.WritePatientProfilePictureInFile(dto.Patient.Username, dto.ProfilePicture);
            return Ok(200);
        }

        [HttpGet("getForPatient/{patientID}")]       // GET /api/medicalRecord/getForPatient/{id}
        public IActionResult GetMedicalRecordForPatient(int patientID)
        {
            MedicalRecord medicalRecord = this.medicalRecordService.GetMedicalRecordForPatient(patientID);
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
            MedicalRecord medicalRecord = this.medicalRecordService.FindPatientMedicalRecordByUsername(username);
            if (medicalRecord == null)
            {
                return BadRequest();
            }
            this.medicalRecordService.ActivatePatientMedicalRecord(medicalRecord.Id);
            return Redirect("http://localhost:51182/index.html#/");
        }
    }
}
