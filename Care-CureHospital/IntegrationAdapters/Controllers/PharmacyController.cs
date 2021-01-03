using Backend;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Backend.Model.Pharmacy;
using IntegrationAdapters.Dto;
using IntegrationAdapters.Mapper;
using Microsoft.AspNetCore.Cors;
using IntegrationAdapters.Validation;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        public PharmacyController()
        {

        }

        [EnableCors("CorsPolicy")]
        [HttpPost]
        [Route("addPharmacy")]
        public IActionResult AddPharmacy([FromBody]PharmaciesDTO dto)
        {
            PharmacyValidation validation = new PharmacyValidation();
            if(!validation.ValidatePharmacy(dto))
            {
                return BadRequest("The data which were entered are incorrect!");
            }
            Pharmacies pharmacy = PharmacyMapper.PharmacyDtoToPharmacy(dto);
            App.Instance().PharmacyService.AddEntity(pharmacy);
            return Ok();
        } 
        
        [EnableCors("CorsPolicy")]
        [HttpGet]
        [Route("getPharmacies")]
        public IActionResult GetPharmacies()
        {
            List<PharmaciesDTO> pdto = new List<PharmaciesDTO>();
            App.Instance().PharmacyService.GetAllEntities().ToList().ForEach(pharmacy => pdto.Add(PharmacyMapper.PharmacyToPharmacyDto(pharmacy)));
            return Ok(pdto);
        }
    }
}
