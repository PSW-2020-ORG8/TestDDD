using System.Collections.Generic;
using System.Linq;
using Backend;
using Microsoft.AspNetCore.Mvc;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        public AllergiesController() { }

        [HttpGet]       // GET /api/allergies
        public IActionResult GetAllAllergies()
        {
            List<AllergiesDto> result = new List<AllergiesDto>();
            App.Instance().AllergiesService.GetAllEntities().ToList().ForEach(allergy => result.Add(AllergiesMapper.AllergiesToAllergiesDto(allergy)));
            return Ok(result);
        }
    }
}
