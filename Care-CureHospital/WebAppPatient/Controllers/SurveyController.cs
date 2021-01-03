using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Patient;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {

        public SurveyController() { }

        [HttpGet] // GET /api/survey
        public IActionResult GetAllSurveys()
        {
            List<SurveyDto> result = new List<SurveyDto>();
            App.Instance().SurveyService.GetAllEntities().ToList().ForEach(survey => result.Add(SurveyMapper.SurveyToSurveyDto(survey)));
            return Ok(result);
        }

        [HttpGet("getSurveyResults")] // GET /api/survey/getSurveyResults
        public IActionResult GetSurveyResults()
        {
            return Ok(QuestionResultMapper.CreateQuestionResultsDto(App.Instance().AnswerService.GetAnswersByQuestion()));
        }

        [HttpGet("getSurveyResultsForDoctors")] // GET /api/survey/getSurveyResults
        public IActionResult GetSurveyResultsForDoctors()
        {
            return Ok(QuestionResultMapper.CreateDoctorResultsDto(App.Instance().SurveyService.GetSurveyResultsForAllDoctors(), App.Instance().DoctorService.GetAllEntities()));
        }

        [HttpPut("filledSurveyForAppointment/{appointmentId}")]       // GET /api/survey/FilledSurveyForAppointment/{appointmentId}
        public IActionResult FilledSurveyForAppointment(int appointmentId)
        {
            return Ok(App.Instance().AppointmentService.FilledSurveyForAppointment(appointmentId));
        }

        [HttpPost]      // POST /api/survey
        public IActionResult AddSurvey(SurveyDto dto)
        {
            Survey survey = SurveyMapper.SurveyDtoToSurvey(dto);
            App.Instance().SurveyService.AddEntity(survey);
            return Ok();
        }
    }
}
