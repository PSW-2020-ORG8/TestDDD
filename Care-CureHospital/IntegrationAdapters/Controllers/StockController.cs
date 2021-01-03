using Backend;
using Backend.Service.RequestServices;
using IntegrationAdapters.Dto;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
      [HttpGet]
      public IActionResult GetMedicament()
      {
           // List<MedicamentDto> result = new List<MedicamentDto>();
           // App.Instance().HttpService.SendGetRequestWithRestSharp();
           return Ok(HttpService.SendGetRequestWithRestSharp());
      }
    }
}
 