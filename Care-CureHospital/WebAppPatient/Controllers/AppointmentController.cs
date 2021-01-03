using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Backend;
using Microsoft.AspNetCore.Mvc;
using Model.Term;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        public AppointmentController() { }

        [HttpGet("getAvailableAppointments")]
        public IActionResult GetAvailableAppointmentsByDateAndDoctorId([FromQuery(Name = "date")] string date, [FromQuery(Name = "doctorId")] int doctorId)
        {
            DoctorWorkDayDto dto = DoctorWorkDayMapper.DoctorWorkDayToDoctorWorkDayDto(
                App.Instance().DoctorWorkDayService.GetDoctorWorkDayByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture), doctorId),
                App.Instance().DoctorWorkDayService.GetAvailableAppointmentsByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture), doctorId));
            
            if (dto == null)
            {
                return NoContent();
            }
            return Ok(dto);
        }    

        [HttpPost]       // POST /api/appointment/
        public IActionResult ScheduleAppointment(SchedulingAppointmentDto dto)
        {
            if (App.Instance().DoctorWorkDayService.ScheduleAppointment(SchedulingAppointmentMapper.AppointmentDtoToAppointment(dto)))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("getPreviousAppointmetsByPatient/{patientId}")]       // GET /api/appointment/getPreviousAppointmetsByPatient/{patientId}
        public IActionResult GetPreviousAppointmentsByPatient(int patientId)
        {
            List<AppointmentDto> result = new List<AppointmentDto>();
            App.Instance().AppointmentService.GetPreviousAppointmetsByPatient(patientId, DateTime.Now).ToList().ForEach(appointment => result.Add(AppointmentMapper.AppointmentToAppointmentDto(appointment)));   
            if(result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("getScheduledAppointmetsByPatient/{patientId}")]       // GET /api/appointment/getScheduledAppointmetsByPatient/{patientId}
        public IActionResult GetScheduledAppointmentsByPatient(int patientId)
        {
            List<AppointmentDto> result = new List<AppointmentDto>();
            App.Instance().AppointmentService.GetScheduledAppointmetsByPatient(patientId, DateTime.Now).ToList().ForEach(appointment => result.Add(AppointmentMapper.AppointmentToAppointmentDto(appointment)));
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("cancelAppointment/{appointmentId}")]       // GET /api/appointment/cancelAppointment/{appointmentId}
        public IActionResult CancelPatientAppointment(int appointmentId)
        {
            Appointment appointmentForCancelation = App.Instance().AppointmentService.GetEntity(appointmentId);
            if (appointmentForCancelation == null)
            {
                return NotFound();
            }
            App.Instance().DoctorWorkDayService.CancelPatientAppointment(appointmentForCancelation.DoctorWorkDayId, appointmentId, DateTime.Now);
            return Ok(App.Instance().AppointmentService.CancelPatientAppointment(appointmentId, DateTime.Now));
        }

        [HttpGet("getAllRecommendedTerms")]       // GET /api/appointment/getAllRecommendedTerms
        public IActionResult GetAllRecommendedTerms([FromQuery(Name = "startDate")] string startDate, [FromQuery(Name = "endDate")] string endDate, [FromQuery(Name = "doctorId")] string doctorId, [FromQuery(Name = "priority")] string priority)
        {
            try
            {
                Dictionary<int, List<Appointment>> availableAppointments = App.Instance().DoctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture), DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture), Int32.Parse(doctorId), priority);
                return Ok(DoctorWorkDayMapper.CreateDoctorWorkDayDtos(App.Instance().DoctorWorkDayService.GetDoctorWorkDaysByIds(availableAppointments.Keys.ToList()), availableAppointments));
            }
            catch
            {
                return BadRequest("The data which were entered are incorrect!");
            }           
        }
    }
}
