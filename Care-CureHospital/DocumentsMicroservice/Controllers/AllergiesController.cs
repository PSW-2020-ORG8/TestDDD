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
    public class AllergiesController : ControllerBase
    {
        private IAllergiesService allergiesService;

        public AllergiesController(IAllergiesService allergiesService) 
        {
            this.allergiesService = allergiesService;
        }

        [HttpGet]       // GET /api/allergies
        public IActionResult GetAllAllergies()
        {
            List<AllergiesDto> result = new List<AllergiesDto>();
            this.allergiesService.GetAllEntities().ToList().ForEach(allergy => result.Add(AllergiesMapper.AllergiesToAllergiesDto(allergy)));
            return Ok(result);
        }
    }
}
