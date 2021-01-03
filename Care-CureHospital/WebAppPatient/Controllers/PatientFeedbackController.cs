using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Adapters;
using Backend.Dto;
using Backend.Model.AllActors;
using Backend.Model.BlogAndNotification;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppPatient.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFeedbackController : ControllerBase
    {
        public PatientFeedbackController() {}

        [Authorize(Roles = Role.Admin)]
        [HttpGet]       // GET /api/patientFeedback
        public IActionResult GetAllFeedbacks()
        {
            List<PatientFeedbackDto> result = new List<PatientFeedbackDto>();
            App.Instance().PatientFeedbackService.GetAllEntities().ToList().ForEach(feedback => result.Add(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(feedback)));
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("getPublishedFeedbacks")]       // GET /api/patientFeedback/getPublishedFeedbacks
        public IActionResult GetPublishedFeedbacks()
        {
            List<PatientFeedbackDto> result = new List<PatientFeedbackDto>();
            App.Instance().PatientFeedbackService.GetPublishedFeedbacks().ToList().ForEach(feedback => result.Add(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(feedback)));
            return Ok(result);
        }

        [Authorize(Roles = Role.Patient)]
        [HttpPost]      // POST /api/patientFeedback
        public IActionResult Add(PatientFeedbackDto dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }
            PatientFeedback patientFeedback = PatientFeedbackMapper.PatientFeedbackDtoToPatientFeedback(dto, null);
            App.Instance().PatientFeedbackService.AddEntity(patientFeedback);
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("publishFeedback/{id}")]       // PUT /api/patientFeedback/publishFeedback/{id}
        public IActionResult PublishFeedback(int id)
        {     
            PatientFeedback result = App.Instance().PatientFeedbackService.PublishPatientFeedback(id);
            if (result == null)
            {
                return NotFound();
            }          
            return Ok(PatientFeedbackMapper.PatientFeedbackToPatientFeedbackDto(result));
        }      
    }
}
