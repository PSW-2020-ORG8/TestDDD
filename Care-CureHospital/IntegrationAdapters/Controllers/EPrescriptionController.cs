using Backend;
using Backend.Model.PatientDoctor;
using IntegrationAdapters.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using IntegrationAdapters.Mapper;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EPrescriptionController : ControllerBase
    {
        public EPrescriptionController() { }

        [HttpGet]
        public IActionResult GetAllEPrescription()
        {
            List<EPrescriptionDto> result = new List<EPrescriptionDto>();
            App.Instance().EPrescriptionService.GetAllEntities().ToList().ForEach(eprescription => result.Add(EPrescriptionMapper.EPrescriptionToEPresctriptionDto(eprescription)));
            return Ok(result);
        }

        [HttpPost] 
        public IActionResult AddEPrescription(EPrescriptionDto dto)
        {
            EPrescription eprescription = EPrescriptionMapper.EPrescriptionDtoToEPrescription(dto);
            App.Instance().EPrescriptionService.AddEntity(eprescription);
            return Ok();
        }

        [HttpGet("getForPatient/{patientID}")]       
        public IActionResult GetEPrescriptionsForPatient(int patientID)
        {
            List<EPrescriptionDto> eprescriptionsForPatient = new List<EPrescriptionDto>();
            App.Instance().EPrescriptionService.GetEPrescriptionsForPatient(patientID).ToList().ForEach(eprescription => eprescriptionsForPatient.Add(EPrescriptionMapper.EPrescriptionToEPresctriptionDto(eprescription)));
            return Ok(eprescriptionsForPatient);
        }

        [HttpGet("findePrescriptionsByDate")]      
        public IActionResult FindePrescriptionsByDate([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "date")] string date)
        {
            List<EPrescriptionDto> result = new List<EPrescriptionDto>();
            App.Instance().EPrescriptionService.FindEPrescriptionsForDateParameter(patientId, date).ToList().ForEach(eprescription => result.Add(EPrescriptionMapper.EPrescriptionToEPresctriptionDto(eprescription)));
            return Ok(result);
        }

        [HttpGet("findEPrescriptionsByComment")]      
        public IActionResult FindPrescriptionsByComment([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "comment")] string comment)
        {
            List<EPrescriptionDto> result = new List<EPrescriptionDto>();
            App.Instance().EPrescriptionService.FindEPrescriptionsForCommentParameter(patientId, comment).ToList().ForEach(eprescription => result.Add(EPrescriptionMapper.EPrescriptionToEPresctriptionDto(eprescription)));
            return Ok(result);
        }

        [HttpPost("send")]
        public IActionResult SendPrescription()
        {
            App.Instance().EPrescriptionService.SendPrescriptionSftp();
            return Ok();
        }
    }
}
